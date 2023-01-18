using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TB.Function.API;
using TB.Function.API.Middlewares;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(builder =>
    {
        builder.UseMiddleware<ExceptionMiddleware>();
    })
    .ConfigureAppConfiguration((host, builder) => ConfigureAppConfiguration(host.HostingEnvironment.ContentRootPath, builder))
    .ConfigureServices((host, services) => services.ConfigureContainer(host.Configuration))
    .Build();

host.Run();

static void ConfigureAppConfiguration(string baseRootPath, IConfigurationBuilder builder)
{
    string EnvironmentName = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT");

    builder
        .SetBasePath(baseRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
        .AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true, reloadOnChange: false)
        .AddEnvironmentVariables();
}
