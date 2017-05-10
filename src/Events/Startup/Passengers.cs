using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class Passengers : Event
    {
        [JsonProperty("Manifest")]
        public PassengerManifest[] Missions { get; private set; }
    }
}
