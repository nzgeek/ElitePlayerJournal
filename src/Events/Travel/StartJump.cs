using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class StartJump : Event, ISystemEvent
    {
        [JsonProperty("JumpType")]
        public JumpType JumpType { get; private set; }

        [JsonProperty("StarSystem")]
        public string SystemName { get; private set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; private set; }
    }
}
