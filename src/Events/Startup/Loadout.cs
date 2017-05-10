using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class Loadout : Event
    {
        [JsonProperty("Ship")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipID")]
        public int ShipId { get; private set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; private set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; private set; }

        [JsonProperty("Modules")]
        public ShipModule[] Modules { get; private set; }
    }
}
