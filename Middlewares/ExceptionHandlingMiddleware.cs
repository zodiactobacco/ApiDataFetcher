using ApiDataFetcher.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace ApiDataFetcher.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

            var response = context.Response;
            response.ContentType = "application/json";

            var (statusCode, message) = exception switch
            {
                ExternalApiException apiEx => ((HttpStatusCode)apiEx.StatusCode, apiEx.Message),
                ArgumentException argEx => (HttpStatusCode.BadRequest, argEx.Message),
                InvalidOperationException opEx => (HttpStatusCode.BadRequest, opEx.Message),
                Exception ex => (HttpStatusCode.InternalServerError, ex.Message)
            };

            response.StatusCode = (int)statusCode;

            var errorResponse = new
            {
                Message = message,
                Detail = statusCode == HttpStatusCode.InternalServerError ? null : exception.Message
            };

            await response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
