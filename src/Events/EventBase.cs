using Newtonsoft.Json;
using System;

namespace NZgeek.ElitePlayerJournal.Events
{
    public class EventBase
    {
        public EventBase()
            : this(EventType.Unknown)
        {
        }

        public EventBase(EventType eventType)
        {
            RawType = eventType.ToString();
        }

        [JsonProperty(PropertyName = "event")]
        public string RawType { get; set; }

        public EventType Type
        {
            get
            {
                if (Enum.TryParse(RawType, true, out EventType eventType))
                    return eventType;

                return EventType.Unknown;
            }
        }
    }
}
