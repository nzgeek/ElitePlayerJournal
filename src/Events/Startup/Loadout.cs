using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class Loadout : Event
    {
        [JsonProperty("Ship")]
        public string ShipType { get; set; }

        [JsonProperty("ShipID")]
        public int ShipId { get; set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; set; }

        [JsonProperty("Modules")]
        public ShipModule[] Modules { get; set; }
    }
}
