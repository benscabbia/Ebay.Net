using System;
using EbayNet.Authentication;
/*
https://developer.ebay.com/api-docs/buy/browse/static/overview.html

Search for and retrieve eBay items and use filters and parameters to create
customized item sets. It also provides the ability for eBay members to add
and remove items and change the quantity of an item in their eBay shopping
cart as well as view the contents of their eBay cart.

*/
namespace EbayNet.BrowseAPIs
{
    public sealed class BrowseAPI
    {
        public BrowseAPI(EbayRestClient ebayRestClient)
        {
           Item = new Item(ebayRestClient);
           ItemSummary = new ItemSummary(ebayRestClient);
        }

        public Item Item { get; }
        public ItemSummary ItemSummary { get; }
    }
}
