using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events.Other
{
    public class ReceiveText : Event
    {
        [JsonProperty("Channel")]
        public string Channel { get; private set; }

        public string From => GetLocalisableText("From");

        public string Message => GetLocalisableText("Message");
    }
}
