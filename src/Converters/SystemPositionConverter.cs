using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events.Types;
using System;

namespace NZgeek.ElitePlayerJournal.Converters
{
    class SystemPositionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SystemPosition);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
                throw new FormatException("Position is not in the expected format.");

            var x = reader.ReadAsDecimal() ?? throw new FormatException("Position is not in the expected format.");
            var y = reader.ReadAsDecimal() ?? throw new FormatException("Position is not in the expected format.");
            var z = reader.ReadAsDecimal() ?? throw new FormatException("Position is not in the expected format.");

            if (!reader.Read() || reader.TokenType != JsonToken.EndArray)
                throw new FormatException("Position is not in the expected format.");

            return new SystemPosition
            {
                X = x,
                Y = y,
                Z = z,
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var systemPosition = value as SystemPosition;

            writer.WriteStartArray();

            writer.WriteValue(systemPosition?.X ?? 0);
            writer.WriteValue(systemPosition?.Y ?? 0);
            writer.WriteValue(systemPosition?.Z ?? 0);

            writer.WriteEndArray();
        }
    }
}
