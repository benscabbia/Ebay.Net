using System;
using System.Threading.Tasks;

/*
    https://developer.ebay.com/api-docs/buy/browse/resources/methods
    Lets shoppers search for specific items by keyword, GTIN, category, product,
    or item aspects and refine the results by using filters.
*/
namespace EbayNet.BrowseAPIs
{
    public sealed class ItemSummary
    {
        private readonly EbayRestClient _ebayRestClient;
        public ItemSummary(EbayRestClient ebayRestClient)
        {
            _ebayRestClient = ebayRestClient;
        }

        public Task Search()
        {
            throw new NotImplementedException();
        }
    }
}
