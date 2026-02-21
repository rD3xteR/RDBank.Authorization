using System.IO.Compression;
using System.Text.Json;
using System.Text.Json.Serialization;

using Core.Configuration;

using Microsoft.AspNetCore.ResponseCompression;

namespace Api.Configuration;

public static class AppBuilderExtensions
{
    /// <summary>
    /// Конфигурирование билдера приложения
    /// </summary>
    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder, string[] args)
    {
        var configuration = builder.PrepareConfigs(args);

// Определяем источники, которым разрешено обращаться к API
        var allowedOrigins = new[]
        {
            "http://localhost:3000",      // React dev server
            "http://localhost:5173",      // Vite (если используете)
        };

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("FrontendPolicy", policy =>
            {
                policy.WithOrigins(allowedOrigins)   // разрешённые источники
                    .AllowAnyMethod()              // любые HTTP методы (GET, POST и т.д.)
                    .AllowAnyHeader()               // любые заголовки
                    .AllowCredentials();             // разрешить куки/авторизационные заголовки
            });
        });

        var services = builder.Services;

        // Добавление контроллеров
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower));
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            });

        services.AddCore(configuration);

        services.AddOpenApi(configuration);

        // Добавляем компрессию ответов
        services
            .AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Except(["application/pdf"]);
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            })
            .Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest)
            .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

        // Check dependencies registration
        services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateScopes = true,
            ValidateOnBuild = true,
        });

        return builder;
    }
}
