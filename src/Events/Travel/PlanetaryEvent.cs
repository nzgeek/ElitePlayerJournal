using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class PlanetaryEvent : Event
    {
        [JsonProperty("Latitude")]
        public decimal Latitude { get; private set; }

        [JsonProperty("Longitude")]
        public decimal Longitude { get; private set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerAtHelm { get; private set; }
    }
}
