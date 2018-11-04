using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class LocalizedAspect
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
