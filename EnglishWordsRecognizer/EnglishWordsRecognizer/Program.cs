using EnglishWordsRecognizer.Jobs;
using TelegramBotCommands.Services;
using TelegramBotManager;
using TelegramBotStorage;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.Configure<BotConfig>(options => builder.Configuration.GetSection("BotConfig").Bind(options));
builder.Services.AddSingleton<CommandsHandlerService>();
builder.Services.AddSingleton<MemoryStorage>();
builder.Services.AddScoped<FacadTelegramBotService>();

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
