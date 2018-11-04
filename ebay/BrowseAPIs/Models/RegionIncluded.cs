using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class RegionIncluded
    {
        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("regionType")]
        public string RegionType { get; set; }
    }
}
