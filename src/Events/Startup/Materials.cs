using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class Materials : Event
    {
        [JsonProperty("Raw")]
        public InventoryItem[] RawMaterials { get; private set; }

        [JsonProperty("Manufactured")]
        public InventoryItem[] ManufacturedMaterials { get; private set; }

        [JsonProperty("Encoded")]
        public InventoryItem[] Data { get; private set; }
    }
}
