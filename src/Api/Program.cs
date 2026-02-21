using Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .Configure(args)
    .Build()
    .Configure();

try
{
    await app.RunAsync();
    return 0;
}
catch (Exception ex)
{
    app.Logger.LogError(ex, "Application failed");
    return 1;
}
