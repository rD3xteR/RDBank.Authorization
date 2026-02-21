using Core.Abstractions;
using Core.Dal;
using Core.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration;

public static class ServiceExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions(configuration);

        services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services
            .AddScoped<IJwtService, JwtService>()
            .AddScoped<IAuthService, AuthService>();

        services.AddMapperProfiles();

        return services;
    }
}
