using ApiDataFetcher.Interfaces;
using ApiDataFetcher.Models.Request;
using ApiDataFetcher.Models.Response;
using ApiDataFetcher.Settings;
using Microsoft.Extensions.Options;

namespace ApiDataFetcher.Services
{
    public class SilverwareDataFetcher : ISilverwareDataFetcher
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly SilverwareDataSettings _settings;
        private readonly ILogger<SilverwareDataFetcher> _logger;

        public SilverwareDataFetcher(
            IHttpClientWrapper httpClientWrapper,
            IOptions<SilverwareDataSettings> settings,
            ILogger<SilverwareDataFetcher> logger)
        {
            _httpClientWrapper = httpClientWrapper;
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task<DailyTotalsResponse> GetDailyTotalsAsync(DailyTotalsRequest request)
        {
            var endpoint = GetEndpointUrl(_settings.Endpoints.DailyTotals);
            _logger.LogInformation("Fetching DailyTotals from {Endpoint}", endpoint);
            return await _httpClientWrapper.PostAsync<DailyTotalsRequest, DailyTotalsResponse>(endpoint, _settings.BearerToken, request);
        }

        public async Task<GetOrdersResponse> GetOrdersAsync(GetOrdersRequest request)
        {
            var endpoint = GetEndpointUrl(_settings.Endpoints.GetOrders);
            _logger.LogInformation("Fetching Orders from {Endpoint}", endpoint);
            return await _httpClientWrapper.PostAsync<GetOrdersRequest, GetOrdersResponse>(endpoint, _settings.BearerToken, request);
        }

        public async Task<GetOrderResponse> GetOrderAsync(GetOrderRequest request)
        {
            var endpoint = GetEndpointUrl(_settings.Endpoints.GetOrder);
            _logger.LogInformation("Fetching Order from {Endpoint}", endpoint);
            return await _httpClientWrapper.PostAsync<GetOrderRequest, GetOrderResponse>(endpoint, _settings.BearerToken, request);
        }

        private string GetEndpointUrl(string relativeEndpoint)
        {
            return $"{_settings.BaseUrl}/{relativeEndpoint.TrimStart('/')}";
        }
    }
}
