
using System;
using System.Net.Http;
using System.Threading.Tasks;
using EbayNet.Extensions;
using Flurl;
using Flurl.Http;
using System.Linq;

namespace EbayNet.Authentication
{
    public sealed class OAuth2Authenticator
    {
        private const string _productionUrl = "https://api.ebay.com/";
        private const string _sandboxUrl = "https://api.sandbox.ebay.com/";
        private const string _OAuthTokenRequestEndpoint = "identity/v1/oauth2/token/";
        private const string _OAuthScopeEndpoint = "oauth/api_scope";
        private Token _token = new Token();
        public Environment Environment { get; }
        public string Base64EncodedOAuthCredentials { get; }

        public OAuth2Authenticator(string clientId, string clientSecret, Environment environment = Environment.Production)
        {
            Environment = environment;
            var OAuthCredentials = $"{clientId}:{clientSecret}";
            Base64EncodedOAuthCredentials = OAuthCredentials.Base64Encode();
        }

        /// <summary> 
        /// Format specification: https://developer.ebay.com/api-docs/static/oauth-base64-credentials.html
        /// </summary> 
        /// <param name="base64EncodedOAuthCredentials"> Base64 encoded "clientId:clientSecret" </param>
        public OAuth2Authenticator(string base64EncodedOAuthCredentials, Environment environment = Environment.Production)
        {
            Environment = environment;
            Base64EncodedOAuthCredentials = base64EncodedOAuthCredentials;
        }

        public async Task<Token> GetTokenAsync()
        {
            if (_token.HasExpired)
            {
                _token = await Authenticate();
            }

            return _token;
        }
        internal async Task<Token> Authenticate()
        {
            var url = ResolveUrlForEnvironment();
            var result = await url
                .AppendPathSegment(_OAuthTokenRequestEndpoint)
                .WithHeaders(
                    new {   
                            Content_Type = "application/x-www-form-urlencoded",
                            Authorization = $"Basic {Base64EncodedOAuthCredentials}"
                    }, 
                    replaceUnderscoreWithHyphen: true)
                .PostUrlEncodedAsync(
                    new { 
                        grant_type = "client_credentials",
                        scope = url.AppendPathSegment(_OAuthScopeEndpoint).Path
                    })
                .ReceiveJson<Token>();

            return result;
        }

        private string ResolveUrlForEnvironment()
        {
           return Environment == Environment.Production ? _productionUrl : _sandboxUrl; 
        }

    }
}
