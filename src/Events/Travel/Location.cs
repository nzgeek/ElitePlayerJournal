using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Location : LocationBase
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

        public string Body => GetLocalisableText("Body");

        [JsonProperty("BodyType")]
        public string BodyType { get; set; }
    }
}
