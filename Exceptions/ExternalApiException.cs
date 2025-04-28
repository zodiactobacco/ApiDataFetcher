namespace ApiDataFetcher.Exceptions
{
    public class ExternalApiException(string message, int statusCode) : Exception(message)
    {
        public int StatusCode { get; } = statusCode;
    }
}
