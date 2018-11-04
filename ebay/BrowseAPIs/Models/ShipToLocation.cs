using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class ShipToLocations
    {
        [JsonProperty("regionIncluded")]
        public RegionIncluded[] RegionIncluded { get; set; }
    }
}
