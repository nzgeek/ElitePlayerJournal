using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class LocationBase : Event
    {
        protected LocationBase(EventType eventType)
            : base(eventType)
        {
        }

        [JsonProperty("StarSystem")]
        public string SystemName { get; set; }

        [JsonProperty("StarPos")]
        public Types.SystemPosition SystemPosition { get; set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; set; }

        public string SystemEconomy => GetLocalisableText("SystemEconomy");

        public string SystemGovernment => GetLocalisableText("SystemGovernment");

        public string SystemSecurity => GetLocalisableText("SystemSecurity");

        [JsonProperty("SystemFaction")]
        public string SystemFaction { get; set; }

        [JsonProperty("FactionState")]
        public string SystemFactionState { get; set; }

        public override string ToString() => $"{base.ToString()} @ {SystemName}";
    }
}
