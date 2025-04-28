using ApiDataFetcher.Models.Request;
using ApiDataFetcher.Models.Response;

namespace ApiDataFetcher.Interfaces
{
    public interface ISilverwareDataFetcher
    {
        Task<DailyTotalsResponse> GetDailyTotalsAsync(DailyTotalsRequest request);
        Task<GetOrdersResponse> GetOrdersAsync(GetOrdersRequest request);
        Task<GetOrderResponse> GetOrderAsync(GetOrderRequest request);
    }
}