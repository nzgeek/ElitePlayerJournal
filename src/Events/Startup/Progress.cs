using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class Progress : Event
    {
        [JsonProperty("Combat")]
        public int Combat { get; set; }

        [JsonProperty("Trade")]
        public int Trade { get; set; }

        [JsonProperty("Explore")]
        public int Exploration { get; set; }

        [JsonProperty("Empire")]
        public int Empire { get; set; }

        [JsonProperty("Federation")]
        public int Federation { get; set; }

        [JsonProperty("CQC")]
        public int CQC { get; set; }
    }
}
