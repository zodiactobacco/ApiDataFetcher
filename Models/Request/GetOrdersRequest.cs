using ApiDataFetcher.Models.Converters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Request
{
    public record GetOrdersRequest
    {
        [Required]
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly Date { get; init; }

        [Required]
        [MinLength(1)]
        public required HashSet<Statuses> Statuses { get; init; }
    }

    public enum Statuses
    {
        Open,
        Closed,
        Voided,
        Unsplit
    }
}
