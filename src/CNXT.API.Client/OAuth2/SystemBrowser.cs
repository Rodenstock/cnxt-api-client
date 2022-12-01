/*
 * CNXT-API
 *
 * The CNXT-API is developed by Rodenstock GmbH to integrate data from measurement devices such as DNEye<sup>®</sup> Scanner, Rodenstock Fundus Scanner, and ImpressionIST<sup>®</sup> into 3rd party applications as well as into several applications of Rodenstock such as WinFit, Rodenstock Consulting etc. If you have any feedback then please feel free to contact us via email. Copyright © Rodenstock GmbH 2022
 *
 * Contact: cnxt@rodenstock.com
 */

namespace CNXT.API.Client.OAuth2
{
    using IdentityModel.OidcClient.Browser;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Security.Authentication.ExtendedProtection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the default system web browser
    /// </summary>
    public class SystemBrowser : IBrowser
    {
        /// <summary>
        /// Gets the currently used port number.
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// The currently used url path.
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemBrowser"/> class.
        /// </summary>
        /// <param name="port">The port number.</param>
        /// <param name="path">The url path.</param>
        public SystemBrowser(int? port = null, string path = null)
        {
            this.path = path;

            if (!port.HasValue)
            {
                Port = GetRandomUnusedPort();
            }
            else
            {
                Port = port.Value;
            }
        }

        /// <summary>
        /// Returns a random unused port.
        /// </summary>
        /// <returns>The free random port.</returns>
        private int GetRandomUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        /// <summary>
        /// Opens the web browser asynchronously.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">The defined cancellation token.</param>
        /// <returns>The browser result.</returns>
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var listener = new LoopbackHttpListener(Port, path))
            {
                OpenBrowser(options.StartUrl);

                try
                {
                    var result = await listener.WaitForCallbackAsync();
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        return new BrowserResult { ResultType = BrowserResultType.UnknownError, Error = "Empty response." };
                    }

                    return new BrowserResult { Response = result, ResultType = BrowserResultType.Success };
                }
                catch (TaskCanceledException ex)
                {
                    return new BrowserResult { ResultType = BrowserResultType.Timeout, Error = ex.Message };
                }
                catch (Exception ex)
                {
                    return new BrowserResult { ResultType = BrowserResultType.UnknownError, Error = ex.Message };
                }
            }
        }

        /// <summary>
        /// Opens the web browser
        /// </summary>
        /// <param name="url">The defined URL to open.</param>
        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// Represents a http listener for the loopback interface.
    /// </summary>
    public class LoopbackHttpListener : IDisposable
    {
        const int DefaultTimeout = 60 * 5; // 5 mins (in seconds)

        private HttpListener httpListener;
        private TaskCompletionSource<string> source = new TaskCompletionSource<string>();
        private string url;

        public string Url => url;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoopbackHttpListener"/> class.
        /// </summary>
        /// <param name="port">The port number.</param>
        /// <param name="path">The url path.</param>
        public LoopbackHttpListener(int port, string path = null)
        {
            path = path == null ? string.Empty : path;

            if (path.StartsWith("/")) path = path.Substring(1);

            url = $"http://127.0.0.1:{port}/{path}";


            httpListener = new HttpListener();
            httpListener.Prefixes.Add(url);

            httpListener.ExtendedProtectionPolicy = new ExtendedProtectionPolicy(PolicyEnforcement.Never);

            try
            {
                httpListener.Start();
            }
            catch (HttpListenerException hlex)
            {
                Console.WriteLine(hlex.Message);
            }
        }

        public void Dispose()
        {
            Task.Run(async () =>
            {
                await Task.Delay(500);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeoutInSeconds">The defined timeout in seconds.</param>
        /// <returns></returns>
        public Task<string> WaitForCallbackAsync(int timeoutInSeconds = DefaultTimeout)
        {
            Task.Run(async () =>
            {
                ProcessRequest(httpListener.GetContext());

                await Task.Delay(timeoutInSeconds * 1000);
                source.TrySetCanceled();
            });

            return source.Task;
        }

        /// <summary>
        /// Processes the given http listener context.
        /// </summary>
        /// <param name="context">The defined http listener context.</param>
        private void ProcessRequest(HttpListenerContext context)
        {
            string queryString = ConstructQueryString(context.Request.QueryString);
            source.TrySetResult($"?{queryString}");

            byte[] rawBody = Encoding.UTF8.GetBytes("<html><body>You are authenticated.</body></html>");
            context.Response.StatusCode = 200;
            context.Response.KeepAlive = false;
            context.Response.ContentLength64 = rawBody.Length;

            var output = context.Response.OutputStream;
            output.Write(rawBody, 0, rawBody.Length);
            context.Response.Close();
        }

        /// <summary>
        /// Constructs a QueryString (string).
        /// Consider this method to be the opposite of "System.Web.HttpUtility.ParseQueryString"
        /// </summary>
        public static string ConstructQueryString(NameValueCollection parameters)
        {
            List<string> items = new List<string>();

            foreach (string name in parameters)
                items.Add(string.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name])));

            return string.Join("&", items.ToArray());
        }
    }
}