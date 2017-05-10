using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class NewCommander : Event
    {
        [JsonProperty("Name")]
        public string CommanderName { get; private set; }

        [JsonProperty("Package")]
        public string StarterPackage { get; private set; }
    }
}
