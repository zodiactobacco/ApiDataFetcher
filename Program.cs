using ApiDataFetcher.Services;
using ApiDataFetcher.Settings;
using Microsoft.OpenApi.Models;
using ApiDataFetcher.Interfaces;
using ApiDataFetcher.Middlewares.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddResponseCaching();

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
    logging.SetMinimumLevel(LogLevel.Information);
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Data Fetcher API",
        Version = "v1",
        Description = "Simple API to fetch daily sales data from SilverWare POS."
    });
});

builder.Services.AddHttpClient<IHttpClientWrapper, HttpClientWrapper>();
builder.Services.AddScoped<ISilverwareDataFetcher, SilverwareDataFetcher>();

builder.Services
    .AddOptions<SilverwareDataSettings>()
    .Bind(builder.Configuration.GetSection("SilverwareDataSettings"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var app = builder.Build();

app.UseExceptionHandlerMiddleware();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DATA FETCHER V1");
});

app.UseHttpsRedirection();
app.UseResponseCaching();
app.MapControllers();

app.Run();