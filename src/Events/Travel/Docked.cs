using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class Docked : DockingEvent, ISystemEvent
    {
        [JsonProperty("StarSystem")]
        public string SystemName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }

        public string StationAllegiance => GetLocalisableText("StationAllegiance");

        public string StationEconomy => GetLocalisableText("StationEconomy");

        public string StationGovernment => GetLocalisableText("StationGovernment");

        [JsonProperty("DistFromStarLS")]
        public decimal DistanceFromStar { get; private set; }

        [JsonProperty("CockpitBreach")]
        public bool IsCanopyBreached { get; private set; }
    }
}
