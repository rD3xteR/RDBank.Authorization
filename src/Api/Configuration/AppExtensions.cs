using Api.Configuration.Routing;
using Api.Middlewares.GlobalExceptionMiddleware;

using Core.Dal;

using Microsoft.EntityFrameworkCore;

namespace Api.Configuration;

public static class AppExtensions
{
    /// <summary>
    /// Конфигурирование приложения
    /// </summary>
    public static WebApplication Configure(this WebApplication app)
    {
        app.Urls.Clear(); // Сбрасываем автоматическую конфигурацию

        app.UseGlobalExceptionMiddleware();

        app
            .UseRouting()
            .UseResponseCompression();

        app.UseCors("FrontendPolicy");
        app.UseAuthentication();
        app.UseAuthorization();

        if (!app.Environment.IsProduction())
        {
            app.UseOpenApi();
        }

        app.UseApi();
        app.RunMigrations();

        return app;
    }

    private static void RunMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
        try
        {
            dbContext.Database.Migrate(); // Создаёт БД и применяет миграции
        }
        catch (Exception ex)
        {
            // Логируем ошибку (можно использовать ILogger)
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Ошибка при применении миграций.");
            // Здесь можно решить, останавливать ли приложение (обычно лучше остановить)
            throw;
        }
    }
}
