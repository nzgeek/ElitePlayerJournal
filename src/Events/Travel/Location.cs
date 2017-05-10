using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Location : LocationBase
    {
        [JsonProperty("Docked")]
        public bool IsDocked { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }

        public string Body => GetLocalisableText("Body");

        [JsonProperty("BodyType")]
        public string BodyType { get; private set; }
    }
}
