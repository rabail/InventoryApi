using System;
using Newtonsoft.Json;

namespace InventoryManagementService
{
    public class InventoryDaysModel
    {
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "allowedArrivalDays")]
        public bool AllowedArrivalDays { get; set; }

        [JsonProperty(PropertyName = "allowedDepartureDays")]
        public bool AllowedDepartureDays { get; set; }
    }
}
