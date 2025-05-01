using ApiDataFetcher.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace ApiDataFetcher.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

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
        var response = context.Response;
        response.ContentType = "application/json";

        var (statusCode, title, message) = exception switch
        {
            ExternalApiException apiEx => ((HttpStatusCode)apiEx.StatusCode, "External API Error", apiEx.Message),
            ArgumentException argEx => (HttpStatusCode.BadRequest, "Invalid Argument", argEx.Message),
            InvalidOperationException opEx => (HttpStatusCode.BadRequest, "Invalid Operation", opEx.Message),
            JsonSerializationException jsonEx => (HttpStatusCode.BadRequest, "Invalid JSON Format", jsonEx.Message),
            JsonReaderException readerEx => (HttpStatusCode.BadRequest, "Malformed JSON", readerEx.Message),
            _ => (HttpStatusCode.InternalServerError, "Internal Server Error", "An unexpected error occurred.")
        };

        _logger.LogError(exception, "Unhandled exception: {Message}. Inner: {Inner}", exception.Message, exception.InnerException?.Message);

        response.StatusCode = (int)statusCode;

        var errorResponse = new
        {
            status = response.StatusCode,
            title,
            message,
            traceId = context.TraceIdentifier
        };

        var json = JsonConvert.SerializeObject(errorResponse);
        await response.WriteAsync(json);
    }
}
