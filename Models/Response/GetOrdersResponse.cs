namespace ApiDataFetcher.Models.Response
{
    public class GetOrdersResponse
    {
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public List<Guid>? Orders { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

}
