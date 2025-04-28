using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Settings
{
    public class SilverwareDataSettings
    {
        [Required(ErrorMessage = "BaseUrl is required")]
        [Url(ErrorMessage = "BaseUrl must be a valid URL")]
        public required string BaseUrl { get; set; }

        [Required(ErrorMessage = "BearerToken is required")]
        public required string BearerToken { get; set; }

        [Required(ErrorMessage = "Endpoints is required")]
        public required Endpoints Endpoints { get; set; }
    }

    public class Endpoints
    {
        [Required(ErrorMessage = "DailyTotals endpoint is required")]
        public required string DailyTotals { get; set; }

        [Required(ErrorMessage = "GetOrders endpoint is required")]
        public required string GetOrders { get; set; }

        [Required(ErrorMessage = "GetOrder endpoint is required")]
        public required string GetOrder { get; set; }
    }
}
