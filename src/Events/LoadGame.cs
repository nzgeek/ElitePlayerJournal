using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events
{
    public class LoadGame : Event
    {
        public LoadGame()
            : base(EventType.LoadGame)
        {
        }

        [JsonProperty("Commander")]
        public string Commander { get; set; }

        [JsonProperty("Ship")]
        public string ShipType { get; set; }

        [JsonProperty("ShipID")]
        public int ShipId { get; set; }

        [JsonProperty("GameMode")]
        public string GameMode { get; set; }

        [JsonProperty("Group")]
        public string PrivateGroupName { get; set; }

        [JsonProperty("Credits")]
        public long Credits { get; set; }

        [JsonProperty("Loan")]
        public long Loan { get; set; }

        public override string ToString() => $"{base.ToString()} => {Commander} ({ShipType} #{ShipId}) {Credits:#,##0} cr";
    }
}
