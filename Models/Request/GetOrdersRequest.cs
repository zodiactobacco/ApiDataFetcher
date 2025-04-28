using ApiDataFetcher.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Request
{
    public class GetOrdersRequest
    {
        [Required]
        [ValidFormat("yyyy-MM-dd")]
        public required string Date { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Statuses list cannot be empty.")]
        [ValidStatuses([0, 1, 2, 3])]
        public required HashSet<byte> Statuses { get; set; }
    }
}
