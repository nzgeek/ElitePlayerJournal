using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class ClearSavedGame : Event
    {
        [JsonProperty("Name")]
        public string CommanderName { get; private set; }
    }
}
