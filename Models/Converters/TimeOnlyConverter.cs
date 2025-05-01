using Newtonsoft.Json;
using System.Globalization;

namespace ApiDataFetcher.Models.Converters
{
    public class TimeOnlyConverter : JsonConverter<TimeOnly?>
    {
        private const string Format = "HH:mm";

        public override TimeOnly? ReadJson(JsonReader reader, Type objectType, TimeOnly? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            if (reader.Value?.ToString() is not string value)
            {
                throw new JsonSerializationException($"Invalid time format. Expected {Format}.");
            }

            return TimeOnly.TryParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var time)
                ? time
                : throw new JsonSerializationException($"Invalid time format. Expected {Format}, got {value}.");
        }

        public override void WriteJson(JsonWriter writer, TimeOnly? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(value.Value.ToString(Format, CultureInfo.InvariantCulture));
            }
        }
    }
}
