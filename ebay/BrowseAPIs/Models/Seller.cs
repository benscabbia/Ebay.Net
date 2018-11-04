using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class Seller
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("feedbackPercentage")]
        public string FeedbackPercentage { get; set; }

        [JsonProperty("feedbackScore")]
        public long FeedbackScore { get; set; }
    }
}
