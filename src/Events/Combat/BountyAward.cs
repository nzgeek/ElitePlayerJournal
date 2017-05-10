using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Combat
{
    public class BountyAward : Event
    {
        [JsonProperty("TotalReward")]
        public decimal Amount { get; private set; }

        [JsonProperty("VictimFaction")]
        public string VictimFactionName { get; private set; }

        [JsonProperty("Target")]
        public string TargetType { get; private set; }

        [JsonProperty("Rewards")]
        public FactionReward[] Bounties { get; private set; }

        [JsonProperty("SharedWithOthers")]
        public int SharedWithPlayers { get; private set; }
    }
}
