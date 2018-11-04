using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class ItemLocation
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
