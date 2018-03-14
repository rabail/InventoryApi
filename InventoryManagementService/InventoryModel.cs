using System;
using Newtonsoft.Json;

namespace InventoryManagementService
{
    public class InventoryModel
    {
        [JsonProperty(PropertyName ="startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName ="endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName ="allowedArrivalDays")]
        public Schedule AllowedArrivalDays { get; set; }

        [JsonProperty(PropertyName ="allowedDepartureDays")]
        public Schedule AllowedDepartureDays { get; set; }

        public class Schedule
        {
            [JsonProperty(PropertyName ="M")]
            public bool Monday { get; set; }

            [JsonProperty(PropertyName = "Tu")]
            public bool Tuesday { get; set; }

            [JsonProperty(PropertyName = "W")]
            public bool Wednesday { get; set; }

            [JsonProperty(PropertyName = "Th")]
            public bool Thursday { get; set; }

            [JsonProperty(PropertyName = "F")]
            public bool Friday { get; set; }

            [JsonProperty(PropertyName = "Sa")]
            public bool Saturday { get; set; }

            [JsonProperty(PropertyName = "Su")]
            public bool Sunday { get; set; }
        }
    }
}
