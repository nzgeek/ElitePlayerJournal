using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class SupercruiseEvent : Event, ISystemEvent
    {
        [JsonProperty("StarSystem")]
        public string SystemName { get; private set; }
    }
}
