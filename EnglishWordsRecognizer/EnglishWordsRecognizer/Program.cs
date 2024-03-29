using CQRS;
using Microsoft.Extensions.Options;
using TB.API.Jobs;
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
using TB.Menu.Entities;
using TB.Core.Configs;
using TB.API.Middlewares;
using TB.Common;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddUserSecrets<Program>(true)
    .AddEnvironmentVariables();

// Add services to the container

// configs
builder.Services.RegisterCQRS();
builder.Services.RoutingModules();

builder.Services.Configure<BotMenuConfig>(options => builder.Configuration.GetSection("BotMenu").Bind(options));
builder.Services.Configure<AzureVisionConfig>(options => builder.Configuration.GetSection("AzureVisionConfig").Bind(options));
builder.Services.Configure<AzureTranslatorConfig>(options => builder.Configuration.GetSection("AzureTranslatorConfig").Bind(options));

builder.Services.Configure<BotCredentialsConfig>(options => builder.Configuration.GetSection("BotConfig").Bind(options));

builder.Services.Configure<GoogleConfig>(options => builder.Configuration.GetSection("GoogleConfig").Bind(options));


builder.Services.AddSingleton(x =>
{
    var options = x.GetRequiredService<IOptions<BotCredentialsConfig>>();

    if (options.Value == null || options.Value.Token == null || options.Value.Url == null)
    {
        throw new ArgumentNullException("Config is empty");
    }

    return new TelegramBotClient(options.Value.Token);
});

// services
builder.Services.AddSingleton<CambridgeDictionaryService>();
builder.Services.AddSingleton<ThesaurusService>();

// Cognitive Services
// builder.Services.AddSingleton<ITranslateService, AzureTranslateService>();
builder.Services.AddSingleton<ITranslateService, GoogleTranslateService>();

builder.Services.AddSingleton<IComputerVisionService, AzureComputerVisionService>();
builder.Services.AddSingleton<ISpeechToTextService, GoogleSpeechToTextService>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBillingPlanService, BillingPlanService>();

builder.Services.ApplyLocalizationModules();

// HTTP
var httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(3);

builder.Services.AddHttpClient<CambridgeDictionaryService>().AddPolicyHandler(httpRetryPolicy);
builder.Services.AddHttpClient<ThesaurusService>().AddPolicyHandler(httpRetryPolicy);
builder.Services.AddHttpClient("AzureTranslator").AddPolicyHandler(httpRetryPolicy);

// Add Hosted
builder.Services.AddHostedService<RunAppJob>();

// DB
var dbConn = builder.Configuration.GetSection("Database").Value!;
builder.Services.ApplyDataBaseDI(dbConn);

//
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
