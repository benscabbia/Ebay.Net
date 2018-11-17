using System;
using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class CurrentBidPrice
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("currency")]
        // TODO: probably enum
        public string Currency { get; set; }
    }
}

