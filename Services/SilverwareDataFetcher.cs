using ApiDataFetcher.Interfaces;
using ApiDataFetcher.Models.Request;
using ApiDataFetcher.Models.Response;
using ApiDataFetcher.Settings;
using Microsoft.Extensions.Options;

namespace ApiDataFetcher.Services
{
    public class SilverwareDataFetcher(
        IHttpClientWrapper httpClientWrapper,
        IOptions<SilverwareDataSettings> settings,
        ILogger<SilverwareDataFetcher> logger) : ISilverwareDataFetcher
    {
        private readonly IHttpClientWrapper _httpClientWrapper = httpClientWrapper;
        private readonly SilverwareDataSettings _settings = settings.Value;
        private readonly ILogger<SilverwareDataFetcher> _logger = logger;

        public async Task<DailyTotalsResponse> GetDailyTotalsAsync(DailyTotalsRequest request)
        => await FetchDataAsync<DailyTotalsRequest, DailyTotalsResponse>(_settings.Endpoints.DailyTotals, request);

        public async Task<GetOrdersResponse> GetOrdersAsync(GetOrdersRequest request)
            => await FetchDataAsync<GetOrdersRequest, GetOrdersResponse>(_settings.Endpoints.GetOrders, request);

        public async Task<GetOrderResponse> GetOrderAsync(GetOrderRequest request)
            => await FetchDataAsync<GetOrderRequest, GetOrderResponse>(_settings.Endpoints.GetOrder, request);

        private async Task<TResponse> FetchDataAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var url = GetEndpointUrl(endpoint);
            _logger.LogInformation("Fetching data from {url}", url);
            return await _httpClientWrapper.PostAsync<TRequest, TResponse>(url, _settings.BearerToken, request);
        }

        private string GetEndpointUrl(string relativeEndpoint)
        {
            return $"{_settings.BaseUrl}/{relativeEndpoint.TrimStart('/')}";
        }
    }
}
