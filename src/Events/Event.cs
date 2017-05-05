using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NZgeek.ElitePlayerJournal.Events
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Event : IComparable<Event>
    {
        public Event()
            : this(EventType.Unknown)
        {
        }

        protected Event(EventType eventType)
        {
            Timestamp = DateTime.UtcNow;
            RawType = eventType.ToString();
        }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        public EventType Type
        {
            get
            {
                if (Enum.TryParse(RawType, true, out EventType eventType))
                    return eventType;

                return EventType.Unknown;
            }
            set
            {
                RawType = value.ToString();
            }
        }

        [JsonProperty(PropertyName = "event")]
        public string RawType { get; set; }

        public override string ToString() => Type == EventType.Unknown
            ? $"[{Timestamp:yyyyMMdd-HHmmss}] <<{RawType}>>"
            : $"[{Timestamp:yyyyMMdd-HHmmss}] {Type}";

        internal JournalFile JournalFile { get; set; }

        internal int LineNumber { get; set; }

        public Journal Journal => JournalFile?.Journal;

        public int CompareTo(Event other)
        {
            var comparison = Timestamp.CompareTo(other.Timestamp);
            if (comparison != 0)
                return comparison;

            comparison = LineNumber.CompareTo(other.LineNumber);
            if (comparison != 0)
                return comparison;

            return Comparer<EventType>.Default.Compare(Type, other.Type);
        }
    }
}
