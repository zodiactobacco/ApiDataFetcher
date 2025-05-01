using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Response
{
    public record GetOrdersResponse
    {
        [Required]
        [JsonProperty("StartDate")]
        public DateTime StartDate { get; init; }

        [Required]
        [JsonProperty("EndDate")]
        public DateTime EndDate { get; init; }

        [JsonProperty("Orders")]
        public IReadOnlyList<Guid> Orders { get; init; } = [];
    }
}