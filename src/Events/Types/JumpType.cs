using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Converters;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonConverter(typeof(EnumConverter<JumpType>))]
    public enum JumpType
    {
        Hyperspace,
        Supercruise,
    }
}
