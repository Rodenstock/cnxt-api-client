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

    /// <summary>
    /// Represents an extension class for OidcClient
    /// </summary>
    public static class OidcClientExtensions
    {
        /// <summary>
        /// Maps a LoginResult to Credentials object
        /// </summary>
        /// <param name="loginResult">The defined login result</param>
        /// <returns>The mapped credentials</returns>
        public static Credentials ToCredentials(this LoginResult loginResult)
            => new Credentials
            {
                AccessToken = loginResult.AccessToken,
                IdentityToken = loginResult.IdentityToken,
                RefreshToken = loginResult.RefreshToken,
                AccessTokenExpiration = loginResult.AccessTokenExpiration
            };

        /// <summary>
        /// Maps a RefreshTokenResult to Credentials object
        /// </summary>
        /// <param name="loginResult">The defined refresh token result</param>
        /// <returns>The mapped credentials</returns>
        public static Credentials ToCredentials(this RefreshTokenResult refreshTokenResult)
            => new Credentials
            {
                AccessToken = refreshTokenResult.AccessToken,
                IdentityToken = refreshTokenResult.IdentityToken,
                RefreshToken = refreshTokenResult.RefreshToken,
                AccessTokenExpiration = refreshTokenResult.AccessTokenExpiration
            };
    }
}
