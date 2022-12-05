using CQRS;
using CQRS.Commands;
using Microsoft.Extensions.Options;
using TB.API.Jobs;
using TB.Audios.Entities;
using TB.ComputerVision;
using TB.ComputerVision.Entities;
using TB.Core.Configs;
using TB.MemoryStorage;
using TB.Menu.Entities;
using TB.Routing;
using TB.Routing.Commands;
using TB.Translator;
using TB.Translator.Entities.Azure;
using TB.User;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container

// configs
builder.Services.RegisterCQRS();
builder.Services.RoutingModules();

builder.Services.Configure<BotMenuConfig>(options => builder.Configuration.GetSection("BotMenu").Bind(options));
builder.Services.Configure<AzureVisionConfig>(options => builder.Configuration.GetSection("AzureVisionConfig").Bind(options));
builder.Services.Configure<AzureTranslatorConfig>(options => builder.Configuration.GetSection("AzureTranslatorConfig").Bind(options));
builder.Services.Configure<AzureSpeechConfig>(options => builder.Configuration.GetSection("AzureSpeechConfig").Bind(options));

builder.Services.Configure<BotCredentialsConfig>(options => builder.Configuration.GetSection("BotConfig").Bind(options));

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
builder.Services.AddSingleton<Storage>();

// Cognitive Services
builder.Services.AddSingleton<ITranslateService, AzureTranslateService>();
builder.Services.AddSingleton<IComputerVisionService, AzureComputerVisionService>();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddHttpClient();

// Add Hosted
builder.Services.AddHostedService<RunAppJob>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
