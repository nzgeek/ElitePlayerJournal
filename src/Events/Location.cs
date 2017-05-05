using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events
{
    public class Location : SystemEntryEvent
    {
        public Location()
            : base(EventType.Location)
        {
        }

        [JsonProperty("Docked")]
        public bool IsDocked { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; set; }
    }
}
