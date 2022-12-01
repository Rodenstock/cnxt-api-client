/*
 * CNXT-API
 *
 * The CNXT-API is developed by Rodenstock GmbH to integrate data from measurement devices such as DNEye<sup>®</sup> Scanner, Rodenstock Fundus Scanner, and ImpressionIST<sup>®</sup> into 3rd party applications as well as into several applications of Rodenstock such as WinFit, Rodenstock Consulting etc. If you have any feedback then please feel free to contact us via email. Copyright © Rodenstock GmbH 2022
 *
 * Contact: cnxt@rodenstock.com
 */

namespace CNXT.API.Client.OAuth2
{
    using System;

    /// <summary>
    /// Represents a the current OAuth2 credentials
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Gets or sets the access token
        /// </summary>
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// Gets or sets the identity token
        /// </summary>
        public string IdentityToken { get; set; } = "";

        /// <summary>
        /// Gets or sets the refresh token
        /// </summary>
        public string RefreshToken { get; set; } = "";

        /// <summary>
        /// Gets or sets the expiration datetime of the currently used access token
        /// </summary>
        public DateTimeOffset AccessTokenExpiration { get; set; }

        /// <summary>
        /// Gets or sets occurred errors 
        /// </summary>
        public string Error { get; set; } = "";

        /// <summary>
        /// Indicates if an error has occurred
        /// </summary>
        public bool IsError => !string.IsNullOrEmpty(Error);
    }
}
