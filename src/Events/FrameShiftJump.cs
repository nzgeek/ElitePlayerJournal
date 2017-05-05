using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events
{
    public class FrameShiftJump : SystemEntryEvent
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
    }
}
