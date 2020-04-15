using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace NZgeek.ElitePlayerJournal.Events
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Event : EventBase, IComparable<Event>
    {
        public Event()
            : this(EventType.Unknown)
        {
        }

        protected Event(EventType eventType)
        {
            Timestamp = DateTime.UtcNow;
            RawType = eventType.ToString();
            UnmappedValues = new Dictionary<string, JToken>();
        }

        internal JournalFile JournalFile { get; set; }

        internal int LineNumber { get; set; }

        public Journal Journal => JournalFile?.Journal;

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonExtensionData]
        protected IDictionary<string, JToken> UnmappedValues { get; }

        public override string ToString() => Type == EventType.Unknown
            ? $"[{Timestamp:yyyyMMdd-HHmmss}] <<{RawType}>>"
            : $"[{Timestamp:yyyyMMdd-HHmmss}] {Type}";

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

        public void LoadJson(string json)
        {
            UnmappedValues.Clear();
            try
            {
                JsonConvert.PopulateObject(json, this);
            }
            catch (JsonSerializationException ex)
            {
                if (ex.InnerException is ArgumentException && ex.InnerException.Message == "An item with the same key has already been added.")
                {
                    Console.WriteLine("    WARNING: JSON with two or more blanked keyed properties detected. " + json);
                    return;
                }
                throw;
            }
        }

        protected string GetLocalisableText(string key)
        {
            if (UnmappedValues.TryGetValue(key + "_Localised", out JToken value))
                return value.Value<string>();

            if (UnmappedValues.TryGetValue(key, out value))
                return value.Value<string>();

            return null;
        }
    }
}
