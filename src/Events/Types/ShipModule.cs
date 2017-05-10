using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ShipModule
    {
        [JsonProperty("Slot")]
        public string Slot { get; private set; }

        [JsonProperty("Item")]
        public string Module { get; private set; }

        [JsonProperty("On")]
        public bool Enabled { get; private set; }

        [JsonProperty("Priority")]
        public int PowerPriority { get; private set; }

        [JsonProperty("Health")]
        public decimal Health { get; private set; }

        [JsonProperty("Value")]
        public decimal Cost { get; private set; }

        [JsonProperty("AmmoInClip")]
        public int AmmoInClip { get; private set; }

        [JsonProperty("AmmoInHopper")]
        public int AmmoInReserve { get; private set; }

        [JsonProperty("EngineerBlueprint")]
        public string EngineerBlueprint { get; private set; }

        [JsonProperty("EngineerLevel")]
        public string EngineerLevel { get; private set; }

        public override string ToString()
        {
            var result = $"[{Slot}] {Module}";

            if (!string.IsNullOrEmpty(EngineerBlueprint))
                result += $" ({EngineerBlueprint} @ {EngineerLevel})";

            return result + $" = {Cost:#,##0}cr";
        }
    }
}
