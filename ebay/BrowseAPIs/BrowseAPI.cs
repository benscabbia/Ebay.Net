using System;
/*
    https://developer.ebay.com/api-docs/buy/browse/static/overview.html
    
    Search for and retrieve eBay items and use filters and parameters to create 
    customized item sets. It also provides the ability for eBay members to add 
    and remove items and change the quantity of an item in their eBay shopping 
    cart as well as view the contents of their eBay cart.

*/
namespace EbayNet.BrowseAPIs
{
    public class BrowseAPI
    {
        public BrowseAPI()
        {
            
        }

        public Item Item { get; set; } 
        public ItemSummary ItemSummary { get; set; } 
    }
}
