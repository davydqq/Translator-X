using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot.Types;
using Telegram.Bot;
using TB.Core.Configs;
using TB.Menu.Entities;

namespace TB.Function.API.Services;

public class RunAppService
{
    private readonly IOptions<BotCredentialsConfig> botCredOptions;

    private readonly ILogger<RunAppService> logger;

    private readonly IOptions<BotMenuConfig> botMenuOptions;

    private readonly TelegramBotClient telegramBotClient;

    public RunAppService(
        IOptions<BotCredentialsConfig> botCredOptions,
        ILogger<RunAppService> logger,
        IOptions<BotMenuConfig> botMenuOptions,
        TelegramBotClient telegramBotClient)
    {
        this.botCredOptions = botCredOptions;
        this.logger = logger;
        this.botMenuOptions = botMenuOptions;
        this.telegramBotClient = telegramBotClient;
    }

    public async Task RunAsync()
    {
        await InitBotAsync();
        await SendMenuAsync(telegramBotClient);
    }

    private async Task SendMenuAsync(TelegramBotClient botClient)
    {
        var newCommands = botMenuOptions.Value.Commands.OrderBy(x => x.Order).Select(x => new BotCommand { Command = x.Name, Description = x.Description });
        await botClient.SetMyCommandsAsync(newCommands);
    }

    private async Task InitBotAsync()
    {
        await telegramBotClient.SetWebhookAsync(botCredOptions.Value.Url);

        logger.LogInformation("WebHook was setted");
    }
}
