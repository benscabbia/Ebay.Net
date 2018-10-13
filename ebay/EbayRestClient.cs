using System;
using System.Threading.Tasks;
using EbayNet.Authentication;
using EbayNet.BrowseAPIs;
namespace EbayNet
{
    public sealed class EbayRestClient
    {
        private OAuth2Authenticator _oAuth2Authenticator;
        public EbayRestClient(OAuth2Authenticator oAuth2Authenticator)
        {
           _oAuth2Authenticator = oAuth2Authenticator; 
        }
        public async Task<T> Request<T>(Func<string, Task<T>> request) 
        {
            var token = await _oAuth2Authenticator.GetTokenAsync().ConfigureAwait(false);
            var response = await request(token.AccessToken).ConfigureAwait(false);
            return response;
        }
    }
}