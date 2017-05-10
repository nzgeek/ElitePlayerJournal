using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;

namespace NZgeek.ElitePlayerJournal.Events.Startup
{
    public class LoadGame : Event
    {
        [JsonProperty("Commander")]
        public string CommanderName { get; private set; }

        [JsonProperty("Ship")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipID")]
        public int ShipId { get; private set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; private set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; private set; }

        [JsonProperty("GameMode")]
        public GameMode GameMode { get; private set; }

        [JsonProperty("StartDead")]
        public bool StartAtRebuy { get; private set; }

        [JsonProperty("StartLanded")]
        public bool StartLanded { get; private set; }

        [JsonProperty("Group")]
        public string PrivateGroupName { get; private set; }

        [JsonProperty("Credits")]
        public decimal Credits { get; private set; }

        [JsonProperty("Loan")]
        public decimal Loan { get; private set; }

        [JsonProperty("FuelLevel")]
        public decimal FuelLevel { get; private set; }

        [JsonProperty("FuelCapacity")]
        public decimal FuelCapacity { get; private set; }

        public override string ToString() => $"{base.ToString()} => {CommanderName} ({ShipType} #{ShipId}) {Credits:#,##0} cr";
    }
}
