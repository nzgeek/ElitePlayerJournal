using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events
{
    public abstract class SystemEntryEvent : Event
    {
        protected SystemEntryEvent(EventType eventType)
            : base(eventType)
        {
        }

        [JsonProperty("StarSystem")]
        public string SystemName { get; set; }

        [JsonProperty("StarPos")]
        public Types.SystemPosition SystemPosition { get; set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomy { get; set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernment { get; set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurity { get; set; }

        [JsonProperty("SystemFaction")]
        public string SystemFaction { get; set; }

        [JsonProperty("FactionState")]
        public string SystemFactionState { get; set; }

        public override string ToString() => $"{base.ToString()} @ {SystemName}";
    }
}
