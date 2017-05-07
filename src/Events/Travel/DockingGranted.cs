using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class DockingGranted : DockingEvent
    {
        [JsonProperty("LandingPad")]
        public int LandingPad { get; set; }
    }
}
