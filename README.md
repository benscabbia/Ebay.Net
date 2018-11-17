# ebay.net

A client library for the [ebay API](https://developer.ebay.com/api-docs/) targeting .NET standard 2.0.


## Usage Examples

```csharp
var client = new EbayClient("clientId", "clientSecret");
var item = await client.BrowseAPI.Item.GetItem("itemId");
var itemSearch = await client.BrowseAPI.ItemSummary.Search("drone", 10);
```

## Supported APIs

Currently, only the Browse API is supported. Ebay.net follows the same hierarchical structure as the official documentation. 

For instance, to call 'Get Item', you would do: `client.BrowseAPI.Item.GetItem(<itemId>);`

- [Browse API](https://developer.ebay.com/api-docs/buy/browse/overview.html)
	- Item Summary
		- [Search](https://developer.ebay.com/api-docs/buy/browse/resources/item_summary/methods/search)
	- Item
		- [Get Item](https://developer.ebay.com/api-docs/buy/browse/resources/item/methods/getItem)
		- [Get Item By Legacy Id](https://developer.ebay.com/api-docs/buy/browse/resources/item/methods/getItemByLegacyId)
		- [Get Item By Item Group](https://developer.ebay.com/api-docs/buy/browse/resources/item/methods/getItemByLegacyId)


