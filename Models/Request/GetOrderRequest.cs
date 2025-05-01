using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Request
{
    public record GetOrderRequest
    {
        [Required]
        public Guid OrderId { get; init; }
    }
}
