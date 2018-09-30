using System;
using System.Threading.Tasks;

/*
    https://developer.ebay.com/api-docs/buy/browse/resources/methods
    Lets you retrieve the details of a specific item or all the items in an 
    item group, which is an item with variations such as color and size. This 
    resource also provides a bridge between the eBay legacy APIs, such as Trading 
    and Finding, and the RESTful APIs, such as Browse, which use different 
    formats for the item IDs. You can use the Browse API to retrieve the basic 
    details of the item and the RESTful item ID using a legacy item ID.
*/
namespace EbayNet.BrowseAPIs
{
    public class Item
    {
        public Item()
        {
        }

        public Task GetItem(){
            throw new NotImplementedException();
        }

        public Task GetItemByLegacyId(){
            throw new NotImplementedException();
        }

        public Task GetItemByItemGroup(){
            throw new NotImplementedException();
        }
    }
}