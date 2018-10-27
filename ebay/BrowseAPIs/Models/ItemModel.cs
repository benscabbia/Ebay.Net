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

    public partial class Image
    {
        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }
    }

    public partial class EstimatedAvailability
    {
        [JsonProperty("estimatedAvailabilityStatus")]
        public string EstimatedAvailabilityStatus { get; set; }

        [JsonProperty("estimatedAvailableQuantity")]
        public long EstimatedAvailableQuantity { get; set; }

        [JsonProperty("estimatedSoldQuantity")]
        public long EstimatedSoldQuantity { get; set; }
    }

    public partial class ItemLocation
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public partial class Price
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("convertedFromValue")]
        public string ConvertedFromValue { get; set; }

        [JsonProperty("convertedFromCurrency")]
        public string ConvertedFromCurrency { get; set; }
    }

    public partial class ReturnTerms
    {
        [JsonProperty("returnsAccepted")]
        public bool ReturnsAccepted { get; set; }
    }

    public partial class Seller
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("feedbackPercentage")]
        public string FeedbackPercentage { get; set; }

        [JsonProperty("feedbackScore")]
        public long FeedbackScore { get; set; }
    }

    public partial class ShipToLocations
    {
        [JsonProperty("regionIncluded")]
        public RegionIncluded[] RegionIncluded { get; set; }
    }

    public partial class RegionIncluded
    {
        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("regionType")]
        public string RegionType { get; set; }
    }

    public partial class ItemModel
    {
        public static ItemModel FromJson(string json) => JsonConvert.DeserializeObject<ItemModel>(json, BrowseAPIs.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ItemModel self) => JsonConvert.SerializeObject(self, BrowseAPIs.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
