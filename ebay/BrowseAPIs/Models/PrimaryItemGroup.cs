using System;
using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class PrimaryItemGroup
    {
        [JsonProperty("itemGroupId")]
        public string ItemGroupId { get; set; }

        [JsonProperty("itemGroupType")]
        public string ItemGroupType { get; set; }

        [JsonProperty("itemGroupHref")]
        public Uri ItemGroupHref { get; set; }

        [JsonProperty("itemGroupTitle")]
        public string ItemGroupTitle { get; set; }

        [JsonProperty("itemGroupImage")]
        public Image ItemGroupImage { get; set; }
    }
}
