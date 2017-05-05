using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events;
using System;

namespace NZgeek.ElitePlayerJournal.Converters
{
    class EventTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EventType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var eventTypeString = reader.ReadAsString();

            if (!Enum.TryParse(eventTypeString, true, out EventType eventType))
                eventType = EventType.Unknown;

            return eventType;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
