using Microsoft.Extensions.DependencyInjection;
using TB.Localization.Services;

namespace TB.Localization;

public static class LocalicationModules
{
    public static void ApplyLocalizationModules(this IServiceCollection services)
    {
        services.AddTransient<ILocalizationService, LocalizationService>();
    }
}
