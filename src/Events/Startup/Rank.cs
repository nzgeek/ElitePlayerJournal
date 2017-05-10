using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class Rank : Event
    {
        [JsonProperty("Combat")]
        public int Combat { get; private set; }

        [JsonProperty("Trade")]
        public int Trade { get; private set; }

        [JsonProperty("Explore")]
        public int Exploration { get; private set; }

        [JsonProperty("Empire")]
        public int Empire { get; private set; }

        [JsonProperty("Federation")]
        public int Federation { get; private set; }

        [JsonProperty("CQC")]
        public int CQC { get; private set; }
    }
}
