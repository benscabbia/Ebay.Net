using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class MarketingPrice
    {
        [JsonProperty("originalPrice")]
        public CurrentBidPrice OriginalPrice { get; set; }

        [JsonProperty("discountPercentage")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long DiscountPercentage { get; set; }

        [JsonProperty("discountAmount")]
        public CurrentBidPrice DiscountAmount { get; set; }
    }
}
