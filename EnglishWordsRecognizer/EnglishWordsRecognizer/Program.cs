using CQRS;
using EnglishWordsRecognizer.Jobs;
using Microsoft.Extensions.DependencyInjection;
using TB.Core.Configs;
using Telegram.Bot;
using TelegramBotCommands.Services;
using TelegramBotImages;
using TelegramBotImages.Entities;
using TelegramBotStorage;
using TelegramBotTranslator;
using TelegramBotTranslator.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container

// configs
builder.Services.RegisterCQRS();

builder.Services.Configure<BotMenuConfig>(options => builder.Configuration.GetSection("BotMenu").Bind(options));
builder.Services.Configure<AzureVisionConfig>(options => builder.Configuration.GetSection("AzureVisionConfig").Bind(options));
builder.Services.Configure<AzureTranslatorConfig>(options => builder.Configuration.GetSection("AzureTranslatorConfig").Bind(options));
builder.Services.Configure<BotCredentialsConfig>(options => builder.Configuration.GetSection("BotConfig").Bind(options));

builder.Services.AddSingleton(x =>
{
    // TODO MAYBE OPTIONS
    var options = x.GetRequiredService<BotCredentialsConfig>();

    if (options.Token == null || options.Url == null)
    {
        throw new ArgumentNullException("Config is empty");
    }

    return new TelegramBotClient(options.Token);
});

// services
builder.Services.AddSingleton<CommandsHandlerService>();
builder.Services.AddSingleton<MemoryStorage>();
builder.Services.AddScoped<FacadTelegramBotService>();

// Cognitive Services
builder.Services.AddScoped<TextProcessService>();
builder.Services.AddScoped<ImageProcessService>();

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
