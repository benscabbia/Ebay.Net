using EbayNet.Authentication;
using EbayNet.BrowseAPIs;
namespace EbayNet
{
    public sealed class EbayClient
    {
        private OAuth2Authenticator _OAuth2Authenticator;
        private EbayRestClient _ebayRestClient;
        public Environment Environment { get; private set; }
        public BrowseAPI BrowseAPI { get; private set; }

        /// <summary>
        /// EbayClient will take care and encode your clientID and clientSecret
        /// </summary>
        /// <param name="clientId">App ID (Client ID)</param>
        /// <param name="clientSecret">Cert ID (Client Secret)</param>
        public EbayClient(string clientId, string clientSecret, Environment environment = Environment.Production)
        {
            Setup(new OAuth2Authenticator(clientId, clientSecret), environment);
        }

        /// <summary>
        /// Format specification: https://developer.ebay.com/api-docs/static/oauth-base64-credentials.html
        /// </summary>
        /// <param name="base64EncodedOAuthCredentials"> Base64 encoded "clientId:clientSecret" </param>
        public EbayClient(string base64EncodedOAuthCredentials, Environment environment = Environment.Production)
        {
            Setup(new OAuth2Authenticator(base64EncodedOAuthCredentials), environment);
        }

        public EbayClient(OAuth2Authenticator authenticator, Environment environment = Environment.Production)
        {
            Setup(authenticator, environment);
        }

        private void Setup(OAuth2Authenticator authenticator, Environment environment)
        {
            _OAuth2Authenticator = authenticator;
            Environment = environment;
            InitializeAPIs();
        }

        private void InitializeAPIs()
        {
            var urlService = new UrlService(Environment);

            _OAuth2Authenticator.UrlService = urlService;
            _ebayRestClient = new EbayRestClient
            {
                OAuth2Authenticator = _OAuth2Authenticator,
                UrlService = urlService
            };

            BrowseAPI = new BrowseAPI(_ebayRestClient);
        }
    }
}
