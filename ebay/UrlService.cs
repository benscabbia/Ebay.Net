namespace EbayNet
{
    public sealed class UrlService
    {
		private const string _productionUrl = "https://api.ebay.com/";
        private const string _sandboxUrl = "https://api.sandbox.ebay.com/";
		public Environment Environment { get; set; }
		public UrlService(Environment environment = Environment.Production)
		{
			Environment = environment;
		}

		public string Url => Environment == Environment.Production ? _productionUrl : _sandboxUrl;
    }
}

