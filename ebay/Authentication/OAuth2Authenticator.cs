
using System;
using System.Net.Http;
using System.Threading.Tasks;
using EbayNet.Extensions;
using Flurl;
using Flurl.Http;
using System.Linq;

namespace EbayNet.Authentication
{
    public sealed class OAuth2Authenticator : IOAuth2Authenticator
    {

        private const string _OAuthTokenRequestEndpoint = "identity/v1/oauth2/token/";
        private const string _OAuthScopeEndpoint = "oauth/api_scope";
        private Token _token = new Token();
        public string Base64EncodedOAuthCredentials { get; }
        public UrlService UrlService { get; set; } = new UrlService();

        public OAuth2Authenticator(string clientId, string clientSecret)
        {
            var OAuthCredentials = $"{clientId}:{clientSecret}";
            Base64EncodedOAuthCredentials = OAuthCredentials.Base64Encode();
        }

        /// <summary>
        /// Format specification: https://developer.ebay.com/api-docs/static/oauth-base64-credentials.html
        /// </summary>
        /// <param name="base64EncodedOAuthCredentials"> Base64 encoded "clientId:clientSecret" </param>
        public OAuth2Authenticator(string base64EncodedOAuthCredentials)
        {
            Base64EncodedOAuthCredentials = base64EncodedOAuthCredentials;
        }

        public async Task<Token> GetTokenAsync()
        {
            if (_token.HasExpired)
            {
                _token = await AuthenticateAsync().ConfigureAwait(false);
            }

            return _token;
        }

        internal async Task<Token> AuthenticateAsync()
        {
            var url = UrlService.Url;

            try
            {
                var result = await url
                    .AppendPathSegment(_OAuthTokenRequestEndpoint)
                    .WithHeaders(
                        new
                        {
                            Content_Type = "application/x-www-form-urlencoded",
                            Authorization = $"Basic {Base64EncodedOAuthCredentials}"
                        },
                        replaceUnderscoreWithHyphen: true)
                    .PostUrlEncodedAsync(
                        new
                        {
                            grant_type = "client_credentials",
                            scope = url.AppendPathSegment(_OAuthScopeEndpoint).Path
                        })
                    .ReceiveJson<Token>()
                    .ConfigureAwait(false);

                return result;
            }
            catch (FlurlHttpException ex)
            {
                throw new EbayException(ex.Message, ex);
            }
        }
    }
}
