using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class Docked : DockingEvent
    {
        [JsonProperty("StarSystem")]
        public string SystemName { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }

        [JsonProperty("StationFaction")]
        public string StationFaction { get; set; }

        [JsonProperty("FactionState")]
        public string StationFactionState { get; set; }

        public string StationAllegiance => GetLocalisableText("StationAllegiance");

        public string StationEconomy => GetLocalisableText("StationEconomy");

        public string StationGovernment => GetLocalisableText("StationGovernment");

        [JsonProperty("DistFromStarLS")]
        public decimal DistanceFromStar { get; set; }

        [JsonProperty("CockpitBreach")]
        public bool IsCanopyBreached { get; set; }
    }
}
