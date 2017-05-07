using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class FrameShiftJump : LocationBase
    {
        public FrameShiftJump()
            : base(EventType.FSDJump)
        {
        }

        [JsonProperty("JumpDist")]
        public decimal Distance { get; set; }

        [JsonProperty("FuelUsed")]
        public decimal FuelUsed { get; set; }

        [JsonProperty("FuelLevel")]
        public decimal FuelLevel { get; set; }

        [JsonProperty("Factions")]
        public SystemFaction[] Factions { get; set; }

        public override string ToString() => $"{base.ToString()} => {Distance}Ly ({FuelUsed}T fuel used, {FuelLevel}T remaining)";
    }
}
