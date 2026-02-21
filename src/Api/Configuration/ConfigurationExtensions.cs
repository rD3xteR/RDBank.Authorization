namespace Api.Configuration;

public static class ConfigurationExtensions
{
    /// <summary>
    /// Чтение конфигураций из всех источников
    /// </summary>
    public static IConfigurationRoot PrepareConfigs(this WebApplicationBuilder builder, string[] args)
    {
        var isNotProduction = !builder.Environment.IsProduction();
        var configuration = builder.Configuration;
        var overrideConfigPath = builder.Configuration["config"];

        configuration.Sources.Clear();
        configuration.AddJsonFile("appsettings.json", true, true);

        configuration
            .AddOverrideJsonFile(builder, overrideConfigPath, isNotProduction)
            .AddEnvironmentVariables()
            .AddCommandLine(args);

        return configuration;
    }

    /// <summary>
    /// Добавления внешних конфигураций
    /// </summary>
    private static IConfigurationBuilder AddOverrideJsonFile(
        this IConfigurationBuilder configuration,
        WebApplicationBuilder builder,
        string? configPath,
        bool optional
    )
    {
        if (string.IsNullOrEmpty(configPath))
        {
            return configuration;
        }

        if (!File.Exists(configPath))
        {
            Console.WriteLine($"Not found configuration file {configPath}");
            return configuration;
        }

        // Получаем информацию о файле
        var file = new FileInfo(configPath);


        // Добавляем найденные файлы в конфигурацию
        configuration.AddJsonFile(file.FullName, optional, true);

        return configuration;
    }
}
