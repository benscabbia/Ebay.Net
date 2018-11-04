// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var item = Item.FromJson(jsonString);

namespace BrowseAPIs.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ItemModel
    {
        [JsonProperty("itemId")]
        public string ItemId { get; set; }

        [JsonProperty("sellerItemRevision")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SellerItemRevision { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("categoryPath")]
        public string CategoryPath { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("conditionId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ConditionId { get; set; }

        [JsonProperty("itemLocation")]
        public ItemLocation ItemLocation { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("additionalImages")]
        public Image[] AdditionalImages { get; set; }

        [JsonProperty("seller")]
        public Seller Seller { get; set; }

        [JsonProperty("estimatedAvailabilities")]
        public EstimatedAvailability[] EstimatedAvailabilities { get; set; }

        [JsonProperty("shipToLocations")]
        public ShipToLocations ShipToLocations { get; set; }

        [JsonProperty("returnTerms")]
        public ReturnTerms ReturnTerms { get; set; }

        [JsonProperty("topRatedBuyingExperience")]
        public bool TopRatedBuyingExperience { get; set; }

        [JsonProperty("buyingOptions")]
        public string[] BuyingOptions { get; set; }

        [JsonProperty("itemAffiliateWebUrl")]
        public Uri ItemAffiliateWebUrl { get; set; }

        [JsonProperty("itemWebUrl")]
        public Uri ItemWebUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("enabledForGuestCheckout")]
        public bool EnabledForGuestCheckout { get; set; }

        [JsonProperty("adultOnly")]
        public bool AdultOnly { get; set; }

        [JsonProperty("categoryId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CategoryId { get; set; }
    }

    public partial class ItemModel
    {
        public static ItemModel FromJson(string json) => JsonConvert.DeserializeObject<ItemModel>(json, BrowseAPIs.Models.Converter.Settings);
    }
}
