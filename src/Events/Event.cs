using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NZgeek.ElitePlayerJournal.Converters;
using System;
using System.Collections.Generic;

namespace NZgeek.ElitePlayerJournal.Events
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Event : EventBase, IComparable<Event>
    {
        public Event()
        {
            Timestamp = DateTime.UtcNow;
            UnmappedValues = new Dictionary<string, JToken>();
        }

        internal JournalFile JournalFile { get; set; }

        internal int LineNumber { get; set; }

        public Journal Journal => JournalFile?.Journal;

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; private set; }

        [JsonExtensionData]
        protected IDictionary<string, JToken> UnmappedValues { get; }

        public override string ToString() => Type == EventType.Unknown
            ? $"[{Timestamp:yyyy'-'MM'-'dd' 'HH':'mm':'ss}] <<{RawType}>>"
            : $"[{Timestamp:yyyy'-'MM'-'dd' 'HH':'mm':'ss}] {Type}";

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

        internal void LoadJson(string json, JsonSerializerSettings settings)
        {
            UnmappedValues.Clear();
            JsonConvert.PopulateObject(json, this, settings);
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
