using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FactionReward
    {
        [JsonProperty("Faction")]
        public string FactionName { get; private set; }

        [JsonProperty("Reward")]
        public decimal Amount { get; private set; }
    }
}
