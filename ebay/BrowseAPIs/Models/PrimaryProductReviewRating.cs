using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class PrimaryProductReviewRating
    {
        [JsonProperty("reviewCount")]
        public long ReviewCount { get; set; }

        [JsonProperty("averageRating")]
        public string AverageRating { get; set; }

        [JsonProperty("ratingHistograms")]
        public RatingHistogram[] RatingHistograms { get; set; }
    }

    public partial class RatingHistogram
    {
        [JsonProperty("rating")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Rating { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
