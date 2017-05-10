using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class DockingEvent : Event
    {
        [JsonProperty("StationName")]
        public string StationName { get; private set; }
    }
}
