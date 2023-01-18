using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using CQRS;
using TB.ComputerVision;
using TB.ComputerVision.Entities;
using TB.Database;
using TB.Localization;
using TB.Meaning;
using TB.Routing;
using TB.Translator;
using TB.Translator.Entities.Azure;
using TB.User;
using Telegram.Bot;
using Polly;
using TB.SpeechToText;
using TB.SpeechToText.Entities;
using TB.BillingPlans;
using TB.Function.API.Services;
using TB.Menu.Entities;
using TB.Core.Configs;

namespace TB.Function.API;

public static class Modules
{
    public static string EnvironmentName => Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT");

    public static bool IsDevelopment => "Development".ToLower() == EnvironmentName.ToLower();

    public static void ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterCQRS();
        services.RoutingModules();

        services.Configure<BotMenuConfig>(options => configuration.GetSection("BotMenu").Bind(options));

        services.Configure<AzureVisionConfig>(options => configuration.GetSection("AzureVisionConfig").Bind(options));
        services.Configure<AzureTranslatorConfig>(options => configuration.GetSection("AzureTranslatorConfig").Bind(options));
        services.Configure<BotCredentialsConfig>(options => configuration.GetSection("BotConfig").Bind(options));

        services.Configure<GoogleConfig>(options => configuration.GetSection("GoogleConfig").Bind(options));


        services.AddSingleton(x =>
        {
            var options = x.GetRequiredService<IOptions<BotCredentialsConfig>>();

            if (options.Value == null || options.Value.Token == null || options.Value.Url == null)
            {
                throw new ArgumentNullException("Config is empty");
            }

            return new TelegramBotClient(options.Value.Token);
        });

        // services
        services.AddSingleton<CambridgeDictionaryService>();
        services.AddSingleton<ThesaurusService>();

        // Cognitive Services
        services.AddSingleton<ITranslateService, AzureTranslateService>();
        services.AddSingleton<IComputerVisionService, AzureComputerVisionService>();
        services.AddSingleton<ISpeechToTextService, GoogleSpeechToTextService>();

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IBillingPlanService, BillingPlanService>();

        services.ApplyLocalizationModules();

        // HTTP
        var httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(3);

        services.AddHttpClient<CambridgeDictionaryService>().AddPolicyHandler(httpRetryPolicy);
        services.AddHttpClient<ThesaurusService>().AddPolicyHandler(httpRetryPolicy);
        services.AddHttpClient("AzureTranslator").AddPolicyHandler(httpRetryPolicy);

        services.AddTransient<RunAppService>();

        // DB
        var dbConn = configuration.GetSection("Database").Value!;
        services.ApplyDataBaseDI(dbConn);
    }
}
