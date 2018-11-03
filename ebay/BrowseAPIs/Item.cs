using System;
using System.Threading.Tasks;
using BrowseAPIs.Models;
using Flurl;
using Flurl.Http;

/*
    https://developer.ebay.com/api-docs/buy/browse/resources/methods
    Lets you retrieve the details of a specific item or all the items in an
    item group, which is an item with variations such as color and size. This
    resource also provides a bridge between the eBay legacy APIs, such as Trading
    and Finding, and the RESTful APIs, such as Browse, which use different
    formats for the item IDs. You can use the Browse API to retrieve the basic
    details of the item and the RESTful item ID using a legacy item ID.

	e.g. https://api.ebay.com/buy/browse/v1/item/v1|
*/
namespace EbayNet.BrowseAPIs
{
    public sealed class Item
    {
        private string _resource = "buy/browse/v1/item";
        private readonly EbayRestClient _ebayRestClient;
        public Item(EbayRestClient ebayRestClient)
        {
            _ebayRestClient = ebayRestClient;
        }

        // /item/{item_id}
        public async Task<ItemModel> GetItem(string itemId)
		{
			var item = await _ebayRestClient.Request<ItemModel>(
				_resource
				.AppendPathSegment($"v1|{itemId}|0", fullyEncode:true)
                .WithHeaders(
                    new {
                            Content_Type = "application/json",
                            X_EBAY_C_ENDUSERCTX = "contextualLocation=country=<2_character_country_code>,zip=<zip_code>,affiliateCampaignId=<ePNCampaignId>,affiliateReferenceId=<referenceId>"
                        }, replaceUnderscoreWithHyphen: true)
			);

			return item;
        }


        // /item/get_item_by_legacy_id
        public Task GetItemByLegacyId(){
            throw new NotImplementedException();
        }


        // /item/get_items_by_item_group
        public Task GetItemByItemGroup(){
            throw new NotImplementedException();
        }
    }
}
