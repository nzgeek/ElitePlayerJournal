using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PassengerManifest
    {
        [JsonProperty("MissionID")]
        public string MissionId { get; private set; }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("VIP")]
        public bool IsVip { get; private set; }

        [JsonProperty("Wanted")]
        public bool IsWanted { get; private set; }

        [JsonProperty("Count")]
        public int Passengers { get; private set; }
    }
}
