using Core.Dal.Models;

using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration;

public static class MapperConfiguration
{
    public static void AddMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
    }
}
