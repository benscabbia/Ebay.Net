using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class EstimatedAvailability
    {
        [JsonProperty("estimatedAvailabilityStatus")]
        public string EstimatedAvailabilityStatus { get; set; }

        [JsonProperty("estimatedAvailableQuantity")]
        public long EstimatedAvailableQuantity { get; set; }

        [JsonProperty("estimatedSoldQuantity")]
        public long EstimatedSoldQuantity { get; set; }
    }
}
