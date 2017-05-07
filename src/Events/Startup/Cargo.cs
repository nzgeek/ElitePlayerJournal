using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class Cargo : Event
    {
        [JsonProperty("Inventory")]
        public InventoryItem[] Inventory { get; set; }
    }
}
