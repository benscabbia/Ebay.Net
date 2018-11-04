using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
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
}
