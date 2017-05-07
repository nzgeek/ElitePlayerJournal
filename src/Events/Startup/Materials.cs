using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class Materials : Event
    {
        [JsonProperty("Raw")]
        public InventoryItem[] RawMaterials { get; set; }

        [JsonProperty("Manufactured")]
        public InventoryItem[] ManufacturedMaterials { get; set; }

        [JsonProperty("Encoded")]
        public InventoryItem[] Data { get; set; }
    }
}
