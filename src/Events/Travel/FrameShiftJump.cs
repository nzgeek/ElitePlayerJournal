using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class FrameShiftJump : LocationBase
    {
        [JsonProperty("JumpDist")]
        public decimal Distance { get; private set; }

        [JsonProperty("FuelUsed")]
        public decimal FuelUsed { get; private set; }

        [JsonProperty("FuelLevel")]
        public decimal FuelLevel { get; private set; }

        public override string ToString() => $"{base.ToString()} => {Distance}Ly ({FuelUsed}T fuel used, {FuelLevel}T remaining)";
    }
}
