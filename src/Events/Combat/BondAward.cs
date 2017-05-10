using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Combat
{
    public class BondAward : Event
    {
        [JsonProperty("Reward")]
        public decimal Amount { get; private set; }

        [JsonProperty("AwardingFaction")]
        public string AwardingFactionName { get; private set; }

        [JsonProperty("VictimFaction")]
        public string VictimFactionName { get; private set; }
    }
}
