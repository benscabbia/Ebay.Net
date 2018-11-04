using System;
using Newtonsoft.Json;

namespace BrowseAPIs.Models
{
    public partial class ShippingOption
    {
        [JsonProperty("shippingServiceCode")]
        public string ShippingServiceCode { get; set; }

        [JsonProperty("shippingCarrierCode")]
        public string ShippingCarrierCode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("shippingCost")]
        public Price ShippingCost { get; set; }

        [JsonProperty("quantityUsedForEstimate")]
        public long QuantityUsedForEstimate { get; set; }

        [JsonProperty("minEstimatedDeliveryDate")]
        public DateTimeOffset MinEstimatedDeliveryDate { get; set; }

        [JsonProperty("maxEstimatedDeliveryDate")]
        public DateTimeOffset MaxEstimatedDeliveryDate { get; set; }

        [JsonProperty("additionalShippingCostPerUnit")]
        public Price AdditionalShippingCostPerUnit { get; set; }

        [JsonProperty("shippingCostType")]
        public string ShippingCostType { get; set; }
    }
}
