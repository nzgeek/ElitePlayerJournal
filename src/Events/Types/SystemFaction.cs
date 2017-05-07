using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SystemFaction
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("FactionState")]
        public string State { get; set; }

        [JsonProperty("Government")]
        public string Government { get; set; }

        [JsonProperty("Influence")]
        public decimal Influence { get; set; }

        public override string ToString() => $"{Name} - {Influence * 100:###.0}% ({Government}, {State})";
    }
}
