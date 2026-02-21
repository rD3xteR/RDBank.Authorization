using Microsoft.OpenApi;

namespace Api.Configuration;

public static class OpenApiExtensions
{
    public static void AddOpenApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi(options =>
        {
            options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
            options.AddDocumentTransformer((document, _, _) =>
            {
                // Создаём схему Bearer JWT
                var bearerScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Введите JWT Bearer токен",
                    In = ParameterLocation.Header,
                    Name = "Authorization"
                };

                document.Components ??= new OpenApiComponents();
                document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
                document.Components.SecuritySchemes["Bearer"] = bearerScheme;

                // Глобальное требование безопасности (кнопка Authorize в Swagger UI)
                var bearerSchemeRef = new OpenApiSecuritySchemeReference("Bearer", document);
                document.Security ??= new List<OpenApiSecurityRequirement>();
                document.Security.Add(new OpenApiSecurityRequirement { [bearerSchemeRef] = [] });

                return Task.CompletedTask;
            });
        });
    }

    public static void UseOpenApi(this WebApplication app)
    {
        // Генерация openapi
        app.MapOpenApi("/openapi/v1.json");

        // Добавление Swagger UI
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "API v1");
            // Меняем префикс: будет доступен по /swagger-ui/index.html
            options.RoutePrefix = "swagger-ui";
        });
    }
}
