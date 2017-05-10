using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SystemFaction
    {
        [JsonProperty("Name")]
        public string FactionName { get; private set; }

        [JsonProperty("FactionState")]
        public string State { get; private set; }

        [JsonProperty("Government")]
        public string Government { get; private set; }

        [JsonProperty("Influence")]
        public decimal Influence { get; private set; }

        public override string ToString() => $"{FactionName} - {Influence * 100:###.0}% ({Government}, {State})";
    }
}
