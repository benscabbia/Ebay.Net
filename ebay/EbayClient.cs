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

        public EbayClient(string clientId, string clientSecret, Environment environment = Environment.Production)
        {
            Setup(new OAuth2Authenticator(clientId, clientSecret), environment);
        }

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
