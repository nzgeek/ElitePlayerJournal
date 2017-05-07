using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class DockingDenied : DockingEvent
    {
        [JsonProperty("Reason")]
        public string Reason { get; set; }
    }
}
