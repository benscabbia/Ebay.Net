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

## Authentication

Ebay.net supports both Production and Sandbox environments. You set the `Environment` enum during initialisation of the client or authenticator like shown in examples below. The default is `Environment.Production`.

You will require your ClientID and your ClientSecret, which you can grab from [here](https://developer.ebay.com/my/auth/).

You authenticate via OAuth2 in any of the following ways: 

```csharp
// Simplest way is to pass your clientId and secret directly
var client = new EbayClient("clientId", "clientSecret", Environment.Production);

// Format specification: https://developer.ebay.com/api-docs/static/oauth-base64-credentials.html
// You can use https://www.base64encode.org and encode: yourClientId:yourClientSecret
var client = new EbayClient("base64encoded");

// Manually create and set the authenticator:
// You can also add your own implementation by implementing IOAuth2Authenticator
var auth = new OAuth2Authenticator("base64encoded");
var client = new EbayClient(auth);
```

Ebay.net will handle token expiration and renew for you.



## Error and Exception Handling 
Any error in the library will result in a generic `EbayException`. You can extract the message to determine the cause of the issue. 

```csharp
try 
{
    var client = new EbayClient(...);
    var item = await client.BrowseAPI.Item.GetItem("Fake-Item-Will-Throw-Exception");
}
catch(EbayException ex)
{
    var message = ex.Message;
    var stackTrace = e.InnerException;
}
```
