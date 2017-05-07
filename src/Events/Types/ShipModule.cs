using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ShipModule
    {
        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("Item")]
        public string Module { get; set; }

        [JsonProperty("On")]
        public bool Enabled { get; set; }

        [JsonProperty("Priority")]
        public int PowerPriority { get; set; }

        [JsonProperty("Health")]
        public decimal Health { get; set; }

        [JsonProperty("Value")]
        public decimal Cost { get; set; }

        [JsonProperty("AmmoInClip")]
        public int AmmoInClip { get; set; }

        [JsonProperty("AmmoInHopper")]
        public int AmmoInReserve { get; set; }

        [JsonProperty("EngineerBlueprint")]
        public string EngineerBlueprint { get; set; }

        [JsonProperty("EngineerLevel")]
        public string EngineerLevel { get; set; }

        public override string ToString()
        {
            var result = $"[{Slot}] {Module}";

            if (!string.IsNullOrEmpty(EngineerBlueprint))
                result += $" ({EngineerBlueprint} @ {EngineerLevel})";

            return result + $" = {Cost:#,##0}cr";
        }
    }
}
