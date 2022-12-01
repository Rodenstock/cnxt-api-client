/*
 * CNXT-API
 *
 * The CNXT-API is developed by Rodenstock GmbH to integrate data from measurement devices such as DNEye<sup>®</sup> Scanner, Rodenstock Fundus Scanner, and ImpressionIST<sup>®</sup> into 3rd party applications as well as into several applications of Rodenstock such as WinFit, Rodenstock Consulting etc. If you have any feedback then please feel free to contact us via email. Copyright © Rodenstock GmbH 2022
 *
 * Contact: cnxt@rodenstock.com
 */

namespace CNXT.API.Client.OAuth2
{
    using IdentityModel.OidcClient;
    using IdentityModel.OidcClient.Results;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a identity service for OAuth2 via Oidc
    /// </summary>
    public class OidcIdentityService
    {
        private readonly string authorityUrl;
        private readonly string clientId;
        private readonly string redirectUrl;
        private readonly string postLogoutRedirectUrl;
        private readonly string scope;
        //private readonly string? clientSecret;
        private readonly string clientSecret;

        private readonly SystemBrowser systemBrowser;

        /// <summary>
        /// Initializes a new instance of the <see cref="OidcIdentityService"/> class.
        /// </summary>
        /// <param name="clientId">The defined client id (default is set to hub).</param>
        /// <param name="redirectUrl">The defined redirect url.</param>
        /// <param name="postLogoutRedirectUrl">The defined post logout redirect url.</param>
        /// <param name="scope">The defined scope (should be set to openid offline_access).</param>
        /// <param name="authorityUrl">The defined authority url (should be set to "https://sso.cnxt.rodenstock.com/auth/realms/cnxt").</param>
        /// <param name="clientSecret">The defined client secret (should be set to empty string).</param>
        //public OidcIdentityService(string clientId, string redirectUrl, string postLogoutRedirectUrl, string scope, string authorityUrl, string? clientSecret = null)
        public OidcIdentityService(string clientId, string redirectUrl, string postLogoutRedirectUrl, string scope, string authorityUrl, string clientSecret = null)
        {
            Uri url = new Uri(redirectUrl);
            this.systemBrowser = new SystemBrowser(url.Port);

            this.authorityUrl = authorityUrl;
            this.clientId = clientId;
            this.redirectUrl = $"http://127.0.0.1:{this.systemBrowser.Port}";
            this.postLogoutRedirectUrl = postLogoutRedirectUrl;
            this.scope = scope;
            this.clientSecret = clientSecret;
        }

        /// <summary>
        /// Authenticates the client
        /// </summary>
        /// <returns>The OAuth2 credentials.</returns>
        public async Task<Credentials> Authenticate()
        {
            try
            {
                OidcClient oidcClient = CreateOidcClient();
                LoginResult loginResult = await oidcClient.LoginAsync(new LoginRequest());
                return loginResult.ToCredentials();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Credentials { Error = ex.ToString() };
            }
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="identityToken">The defined identity token.</param>
        /// <returns></returns>
        //public async Task<LogoutResult> Logout(string? identityToken)
        public async Task<LogoutResult> Logout(string identityToken)
        {
            OidcClient oidcClient = CreateOidcClient();
            LogoutResult logoutResult = await oidcClient.LogoutAsync(new LogoutRequest { IdTokenHint = identityToken });
            return logoutResult;
        }

        /// <summary>
        /// Refreshes the access and the refresh token.
        /// </summary>
        /// <param name="refreshToken">The defined refresh token.</param>
        /// <returns>The refreshed OAuth2 credentials.</returns>
        public async Task<Credentials> RefreshToken(string refreshToken)
        {
            try
            {
                OidcClient oidcClient = CreateOidcClient();
                RefreshTokenResult refreshTokenResult = await oidcClient.RefreshTokenAsync(refreshToken);
                return refreshTokenResult.ToCredentials();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Credentials { Error = ex.ToString() };
            }
        }

        /// <summary>
        /// Creates a new Oidc client instance.
        /// </summary>
        /// <returns>The Oidc client instance.</returns>
        private OidcClient CreateOidcClient()
        {
            var options = new OidcClientOptions
            {
                Authority = this.authorityUrl,
                ClientId = this.clientId,
                Scope = this.scope,
                RedirectUri = this.redirectUrl,
                ClientSecret = this.clientSecret,
                PostLogoutRedirectUri = this.postLogoutRedirectUrl,
                FilterClaims = false,
                Browser = this.systemBrowser
            };

            var oidcClient = new OidcClient(options);
            return oidcClient;
        }
    }
}
