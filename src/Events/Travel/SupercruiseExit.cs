using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Travel
{
    public class SupercruiseExit : SupercruiseEvent
    {
        public string Body => GetLocalisableText("Body");

        [JsonProperty("BodyType")]
        public string BodyType { get; private set; }
    }
}
