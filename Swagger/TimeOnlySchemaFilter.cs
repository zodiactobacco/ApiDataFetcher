using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiDataFetcher.Swagger
{
    public class TimeOnlySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(TimeOnly) || context.Type == typeof(TimeOnly?))
            {
                schema.Type = "string";
                schema.Format = "time";
                schema.Example = new OpenApiString("22:00");
                schema.Pattern = @"^\d{2}:\d{2}$";
            }
        }
    }
}
