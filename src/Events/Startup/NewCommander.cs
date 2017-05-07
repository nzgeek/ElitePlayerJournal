using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class NewCommander : Event
    {
        [JsonProperty("Name")]
        public string CommanderName { get; set; }

        [JsonProperty("Package")]
        public string StarterPackage { get; set; }
    }
}
