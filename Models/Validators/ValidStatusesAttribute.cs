using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ApiDataFetcher.Models.Validators
{
    public class ValidStatusesAttribute(byte[] validStatuses) : ValidationAttribute
    {
        private readonly HashSet<byte> _validStatuses = [.. validStatuses];

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IEnumerable<byte> statuses)
            {
                foreach (var status in statuses)
                {
                    if (!_validStatuses.Contains(status))
                    {
                        var errorMessage = $"One or more statuses are invalid. Statuses must be in range: {string.Join(", ", _validStatuses)}.";
                        return new ValidationResult(errorMessage);
                    }
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("The status list is invalid.");
        }
    }
}
