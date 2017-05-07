using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class LoadGame : Event
    {
        public LoadGame()
            : base(EventType.LoadGame)
        {
        }

        [JsonProperty("Commander")]
        public string CommanderName { get; set; }

        [JsonProperty("Ship")]
        public string ShipType { get; set; }

        [JsonProperty("ShipID")]
        public int ShipId { get; set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; set; }

        [JsonProperty("GameMode")]
        public GameMode GameMode { get; set; }

        [JsonProperty("StartDead")]
        public bool StartAtRebuy { get; set; }

        [JsonProperty("StartLanded")]
        public bool StartLanded { get; set; }

        [JsonProperty("Group")]
        public string PrivateGroupName { get; set; }

        [JsonProperty("Credits")]
        public decimal Credits { get; set; }

        [JsonProperty("Loan")]
        public decimal Loan { get; set; }

        [JsonProperty("FuelLevel")]
        public decimal FuelLevel { get; set; }

        [JsonProperty("FuelCapacity")]
        public decimal FuelCapacity { get; set; }

        public override string ToString() => $"{base.ToString()} => {CommanderName} ({ShipType} #{ShipId}) {Credits:#,##0} cr";
    }
}
