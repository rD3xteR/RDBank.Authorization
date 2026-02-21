using System.Reflection;

namespace Api.Configuration.Routing;

public static class ApiExtensions
{
    public static void UseApi(this IEndpointRouteBuilder builder)
    {
        builder
            .MapEndpoints();
    }

    /// <summary>
    /// Регистрация всех эндпоинтов
    /// </summary>
    private static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpointRegisters = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x is { IsAbstract: true, IsInterface: false } && typeof(IEndpointsRegister).IsAssignableFrom(x))
            .ToList();

        foreach (var endpointRegister in endpointRegisters)
        {
            var mapMethod = endpointRegister.GetMethod(
                nameof(IEndpointsRegister.Map),
                BindingFlags.Public | BindingFlags.Static,
                [typeof(IEndpointRouteBuilder)]
                );

            if (mapMethod is null)
            {
                continue;
            }

            try
            {
                mapMethod.Invoke(null, [builder]);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to map endpoints for {endpointRegister.FullName}", ex);
            }
        }

        return builder;
    }
}
