using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PassengerManifest
    {
        [JsonProperty("MissionID")]
        public string MissionId { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("VIP")]
        public bool IsVip { get; set; }

        [JsonProperty("Wanted")]
        public bool IsWanted { get; set; }

        [JsonProperty("Count")]
        public int Passengers { get; set; }
    }
}
