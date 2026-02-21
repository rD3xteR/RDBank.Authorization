namespace Api.Configuration;

public static class OpenApiExtensions
{
    public static void AddOpenApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
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
