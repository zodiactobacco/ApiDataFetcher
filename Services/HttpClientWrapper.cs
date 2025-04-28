using ApiDataFetcher.Exceptions;
using ApiDataFetcher.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiDataFetcher.Services
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpClientWrapper> _logger;

        public HttpClientWrapper(HttpClient httpClient, ILogger<HttpClientWrapper> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, string token, TRequest request)
        {
            AddAuthorizationHeader(token);

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _logger.LogDebug("Sending POST request to {Endpoint} with body: {RequestBody}", endpoint, json);
            var response = await _httpClient.PostAsync(endpoint, content);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("External API {Endpoint} returned error: {StatusCode}, {ErrorContent}", endpoint, response.StatusCode, result);
                throw new ExternalApiException($"External API {endpoint} failed with status: {response.StatusCode}: {result}", (int)response.StatusCode);
            }

            _logger.LogDebug("Received response from {Endpoint}: {Response}", endpoint, result);
            return JsonConvert.DeserializeObject<TResponse>(result)!;
        }

        private void AddAuthorizationHeader(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                _logger.LogError("Bearer token is not configured.");
                throw new InvalidOperationException("Bearer token is not configured.");
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
