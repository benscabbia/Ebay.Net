using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class ReturnTerms
    {
        [JsonProperty("returnsAccepted")]
        public bool ReturnsAccepted { get; set; }
    }
}
