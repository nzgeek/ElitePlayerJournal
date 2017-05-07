using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class InventoryItem
    {
        [JsonProperty("Name")]
        public string Item { get; set; }

        [JsonProperty("Count")]
        public int Quantity { get; set; }

        public override string ToString() => $"{Item}: {Quantity}";
    }
}
