using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class LocationBase : Event, ISystemEvent
    {
        [JsonProperty("StarSystem")]
        public string SystemName { get; private set; }

        [JsonProperty("StarPos")]
        public Types.SystemPosition SystemPosition { get; private set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; private set; }

        public string SystemEconomy => GetLocalisableText("SystemEconomy");

        public string SystemGovernment => GetLocalisableText("SystemGovernment");

        public string SystemSecurity => GetLocalisableText("SystemSecurity");

        public override string ToString() => $"{base.ToString()} @ {SystemName}";
    }
}
