using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Other
{
    public class SendText : Event
    {
        [JsonProperty("To")]
        public string To { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
