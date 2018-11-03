using System.Threading.Tasks;
using EbayNet.Authentication;
using Flurl;
using Flurl.Http;

namespace EbayNet
{
    public sealed class EbayRestClient
    {
        public IOAuth2Authenticator OAuth2Authenticator { get; set; }
        public UrlService UrlService { get; set; } = new UrlService();

        public async Task<T> Request<T>(IFlurlRequest flurlRequest)
        {
            var token = await OAuth2Authenticator.GetTokenAsync();

            flurlRequest.Url = Url.Combine(UrlService.Url, flurlRequest.Url);

            return await flurlRequest
                .WithOAuthBearerToken(token.AccessToken)
                .GetAsync()
                .ReceiveJson<T>();
        }
    }
}
