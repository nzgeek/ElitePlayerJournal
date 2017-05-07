using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Converters;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonConverter(typeof(EnumConverter<GameMode>))]
    public enum GameMode
    {
        Open,
        Solo,
        Group,
    }
}
