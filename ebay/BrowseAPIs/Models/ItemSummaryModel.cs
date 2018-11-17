namespace BrowseAPIs.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ItemSummaryModel
    {
        [JsonProperty("itemId")]
        public string ItemId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("price")]
        public CurrentBidPrice Price { get; set; }

        [JsonProperty("itemHref")]
        public Uri ItemHref { get; set; }

        [JsonProperty("seller")]
        public Seller Seller { get; set; }

        [JsonProperty("marketingPrice", NullValueHandling = NullValueHandling.Ignore)]
        public MarketingPrice MarketingPrice { get; set; }

        [JsonProperty("condition")]
        // TODO: should be enum https://developer.ebay.com/devzone/finding/callref/enums/conditionIdList.html
        public string Condition { get; set; }

        [JsonProperty("conditionId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ConditionId { get; set; }

        [JsonProperty("thumbnailImages")]
        public Image[] ThumbnailImages { get; set; }

        [JsonProperty("shippingOptions")]
        public ShippingOption[] ShippingOptions { get; set; }

        [JsonProperty("buyingOptions")]
        // TODO: should be enum: https://developer.ebay.com/api-docs/buy/static/ref-buy-browse-filters.html#buyingOptions
        public string[] BuyingOptions { get; set; }

        [JsonProperty("currentBidPrice")]
        public CurrentBidPrice CurrentBidPrice { get; set; }

        [JsonProperty("epid", NullValueHandling = NullValueHandling.Ignore)]
        public string Epid { get; set; }

        [JsonProperty("itemAffiliateWebUrl")]
        public Uri ItemAffiliateWebUrl { get; set; }

        [JsonProperty("itemWebUrl")]
        public Uri ItemWebUrl { get; set; }

        [JsonProperty("itemLocation")]
        public ItemLocation ItemLocation { get; set; }

        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("additionalImages")]
        public Image[] AdditionalImages { get; set; }

        [JsonProperty("adultOnly")]
        public bool AdultOnly { get; set; }
    }

    public partial class ItemSummary
    {
        public static ItemSummaryModel FromJson(string json) => JsonConvert.DeserializeObject<ItemSummaryModel>(json, Converter.Settings);
    }
}
