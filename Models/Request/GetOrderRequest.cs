using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Request
{
    public class GetOrderRequest
    {
        [Required]
        public Guid OrderId { get; set; }
    }
}
