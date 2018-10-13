using EbayNet.Authentication;
using EbayNet.BrowseAPIs;
namespace EbayNet
{
    public sealed class EbayClient
    {
        private OAuth2Authenticator _OAuth2Authenticator;
        private string _ebayAPIUrl = "https://api.ebay.com";
        private string oauth2Url = "/identity/v1/oauth2/token";
        private EbayRestClient _ebayRestClient;
        public Environment Environment { get; }
        public BrowseAPI BrowseAPI { get; private set; }
        public EbayClient(string clientId, string clientSecret, Environment environment = Environment.Production)
        {
           _OAuth2Authenticator = new OAuth2Authenticator(clientId, clientSecret, environment); 
           Environment = environment;
           InitializeAPIs();
        }

        public EbayClient(string base64EncodedOAuthCredentials, Environment environment = Environment.Production)
        {
            _OAuth2Authenticator = new OAuth2Authenticator(base64EncodedOAuthCredentials, environment);            
            Environment = environment;
            InitializeAPIs();
        }

        public EbayClient(OAuth2Authenticator authenticator)
        {
            _OAuth2Authenticator = authenticator;
            Environment = authenticator.Environment;
            InitializeAPIs();
        }
        
        private void InitializeAPIs()
        {
            _ebayRestClient = new EbayRestClient(_OAuth2Authenticator);
            BrowseAPI = new BrowseAPI(_ebayRestClient);
        }
    }
}
