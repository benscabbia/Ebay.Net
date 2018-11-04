using System;
using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class Image
    {
        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }
    }
}
