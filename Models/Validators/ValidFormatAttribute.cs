using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ApiDataFetcher.Models.Validators
{
    public class ValidFormatAttribute(string format) : ValidationAttribute
    {
        private readonly string _format = format;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string str || DateTime.TryParseExact(str, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                return ValidationResult.Success;

            var displayName = validationContext.DisplayName ?? validationContext.MemberName ?? "Value";
            return new ValidationResult($"{displayName} must be in format {_format}.");
        }
    }
}
