using ApiDataFetcher.Exceptions;
using ApiDataFetcher.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiDataFetcher.Services
{
    public class HttpClientWrapper(HttpClient httpClient, ILogger<HttpClientWrapper> logger) : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<HttpClientWrapper> _logger = logger;

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, string token, TRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            _logger.LogDebug("Sending POST request to {Endpoint} with body: {RequestBody}", url, json);

            using var response = await _httpClient.SendAsync(requestMessage);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("External API {Endpoint} returned error: {StatusCode}, {ErrorContent}", url, response.StatusCode, result);
                throw new ExternalApiException($"External API {url} failed with status: {response.StatusCode}: {JsonConvert.DeserializeAnonymousType(result, new { Message = ""})}", (int)response.StatusCode);
            }

            _logger.LogDebug("Received response from {Endpoint}: {Response}", url, result);
            return JsonConvert.DeserializeObject<TResponse>(result)!;
        }
    }
}
