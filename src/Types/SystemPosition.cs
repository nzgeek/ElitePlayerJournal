using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Converters;

namespace NZgeek.ElitePlayerJournal.Types
{
    [JsonConverter(typeof(SystemPositionConverter))]
    public class SystemPosition
    {
        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Z { get; set; }

        public override string ToString() => $"[{X}, {Y}, {Z}]";
    }
}
