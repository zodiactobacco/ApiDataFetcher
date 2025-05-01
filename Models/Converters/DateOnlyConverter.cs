using Newtonsoft.Json;
using System.Globalization;

namespace ApiDataFetcher.Models.Converters
{
    public class DateOnlyConverter : JsonConverter<DateOnly?>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly? ReadJson(JsonReader reader, Type objectType, DateOnly? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            if (reader.Value?.ToString() is not string value)
            {
                throw new JsonSerializationException($"Invalid date format. Expected {Format}.");
            }

            return DateOnly.TryParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)
                ? date
                : throw new JsonSerializationException($"Invalid date format. Expected {Format}, got {value}.");
        }

        public override void WriteJson(JsonWriter writer, DateOnly? value, JsonSerializer serializer)
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
