using Newtonsoft.Json;
using System;

namespace NZgeek.ElitePlayerJournal.Converters
{
    class EnumConverter<EnumType> : JsonConverter
        where EnumType : struct
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EnumType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var valueString = reader.Value?.ToString();

            if (Enum.TryParse(valueString, true, out EnumType enumValue))
                return enumValue;

            throw new FormatException($"Unknown enum value {valueString}.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
