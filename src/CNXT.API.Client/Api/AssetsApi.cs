/*
 * CNXT-API
 *
 * The CNXT-API is developed by Rodenstock GmbH to integrate data from measurement devices such as DNEye<sup>®</sup> Scanner, Rodenstock Fundus Scanner, and ImpressionIST<sup>®</sup> into 3rd party applications as well as into several applications of Rodenstock such as WinFit, Rodenstock Consulting etc. If you have any feedback then please feel free to contact us via email. Copyright © Rodenstock GmbH 2022
 *
 * The version of the OpenAPI document: 1.5.0
 * Contact: cnxt@rodenstock.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using RestSharp;
using CNXT.API.Client.Client;
using CNXT.API.Client.Model;

namespace CNXT.API.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAssetsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Retrieves available DNEye Scanner assets according to the defined asset ID.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CNXT.API.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the asset</param>
        /// <returns>DNEyeScannerAssetsResponse</returns>
        DNEyeScannerAssetsResponse GetDNEyeScannerAssets (string id);

        /// <summary>
        /// Retrieves available DNEye Scanner assets according to the defined asset ID.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CNXT.API.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the asset</param>
        /// <returns>ApiResponse of DNEyeScannerAssetsResponse</returns>
        ApiResponse<DNEyeScannerAssetsResponse> GetDNEyeScannerAssetsWithHttpInfo (string id);
        /// <summary>
        /// Retrieves available ImpressionIST assets according to the defined asset ID.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CNXT.API.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the asset</param>
        /// <returns>ImpressionISTAssetsResponse</returns>
        ImpressionISTAssetsResponse GetImpressionISTAssets (string id);

        /// <summary>
        /// Retrieves available ImpressionIST assets according to the defined asset ID.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CNXT.API.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the asset</param>
        /// <returns>ApiResponse of ImpressionISTAssetsResponse</returns>
        ApiResponse<ImpressionISTAssetsResponse> GetImpressionISTAssetsWithHttpInfo (string id);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AssetsApi : IAssetsApi
    {
        private CNXT.API.Client.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AssetsApi(String basePath)
        {
            this.Configuration = new CNXT.API.Client.Client.Configuration { BasePath = basePath };

            ExceptionFactory = CNXT.API.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsApi"/> class
        /// </summary>
        /// <returns></returns>
        public AssetsApi()
        {
            this.Configuration = CNXT.API.Client.Client.Configuration.Default;

            ExceptionFactory = CNXT.API.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AssetsApi(CNXT.API.Client.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = CNXT.API.Client.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = CNXT.API.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public CNXT.API.Client.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public CNXT.API.Client.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Retrieves available DNEye Scanner assets according to the defined asset ID. 
        /// </summary>
        /// <exception cref="CNXT.API.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the asset</param>
        /// <returns>DNEyeScannerAssetsResponse</returns>
        public DNEyeScannerAssetsResponse GetDNEyeScannerAssets (string id)
        {
             ApiResponse<DNEyeScannerAssetsResponse> localVarResponse = GetDNEyeScannerAssetsWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieves available DNEye Scanner assets according to the defined asset ID. 
        /// </summary>
        /// <exception cref="CNXT.API.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the asset</param>
        /// <returns>ApiResponse of DNEyeScannerAssetsResponse</returns>
        public ApiResponse<DNEyeScannerAssetsResponse> GetDNEyeScannerAssetsWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AssetsApi->GetDNEyeScannerAssets");

            var localVarPath = "/remote/dneye/{id}/assets";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter

            // authentication (oAuth2AuthCode) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDNEyeScannerAssets", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<DNEyeScannerAssetsResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (DNEyeScannerAssetsResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(DNEyeScannerAssetsResponse)));
        }

        /// <summary>
        /// Retrieves available ImpressionIST assets according to the defined asset ID. 
        /// </summary>
        /// <exception cref="CNXT.API.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the asset</param>
        /// <returns>ImpressionISTAssetsResponse</returns>
        public ImpressionISTAssetsResponse GetImpressionISTAssets (string id)
        {
             ApiResponse<ImpressionISTAssetsResponse> localVarResponse = GetImpressionISTAssetsWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieves available ImpressionIST assets according to the defined asset ID. 
        /// </summary>
        /// <exception cref="CNXT.API.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">ID of the asset</param>
        /// <returns>ApiResponse of ImpressionISTAssetsResponse</returns>
        public ApiResponse<ImpressionISTAssetsResponse> GetImpressionISTAssetsWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AssetsApi->GetImpressionISTAssets");

            var localVarPath = "/remote/impressionist/{id}/assets";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter

            // authentication (oAuth2AuthCode) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetImpressionISTAssets", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ImpressionISTAssetsResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ImpressionISTAssetsResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ImpressionISTAssetsResponse)));
        }

    }
}
