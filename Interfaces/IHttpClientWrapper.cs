namespace ApiDataFetcher.Interfaces
{
    public interface IHttpClientWrapper
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, string token, TRequest request);
    }
}
