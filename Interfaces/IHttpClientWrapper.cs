namespace ApiDataFetcher.Interfaces
{
    public interface IHttpClientWrapper
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, string token, TRequest request);
    }
}
