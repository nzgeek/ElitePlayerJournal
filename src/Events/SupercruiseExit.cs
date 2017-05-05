using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events
{
    public class SupercruiseExit : SupercruiseEvent
    {
        public SupercruiseExit()
            : base(EventType.SupercruiseExit)
        {
        }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; set; }
    }
}
