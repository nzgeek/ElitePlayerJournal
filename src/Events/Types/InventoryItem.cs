using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class InventoryItem
    {
        [JsonProperty("Name")]
        public string Item { get; private set; }

        [JsonProperty("Count")]
        public int Quantity { get; private set; }

        public override string ToString() => $"{Item}: {Quantity}";
    }
}
