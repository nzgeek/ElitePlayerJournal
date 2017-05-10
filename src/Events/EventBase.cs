using Newtonsoft.Json;
using System;

namespace NZgeek.ElitePlayerJournal.Events
{
    public class EventBase
    {
        public EventBase()
        {
            RawType = nameof(EventType.Unknown);
        }

        [JsonProperty(PropertyName = "event")]
        public string RawType { get; internal set; }

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
