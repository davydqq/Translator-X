using Microsoft.Extensions.Options;
using Telegram.Bot;
using TelegramBotManager.Configs;

namespace TelegramBotManager;

public static class BotManager
{
    private static TelegramBotClient? botClient = null;

    public static async Task<TelegramBotClient> GetBotClientAsync(IOptions<BotCredentialsConfig> config, bool reInit = false)
    {
        if (botClient != null && !reInit)
        {
            return botClient;
        }

        if (config.Value.Token == null || config.Value.Url == null)
        {
            throw new ArgumentNullException("Config is empty");
        }

        botClient = new TelegramBotClient(config.Value.Token);

        await botClient.SetWebhookAsync(config.Value.Url);

        return botClient;
    }
}