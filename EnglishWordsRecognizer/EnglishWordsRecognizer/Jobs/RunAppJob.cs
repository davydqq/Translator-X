using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotCommands.Services;
using TelegramBotManager;
using TelegramBotManager.Configs;

namespace EnglishWordsRecognizer.Jobs
{
    public class RunAppJob : IHostedService
    {
        private readonly IOptions<BotCredentialsConfig> botCredOptions;

        private readonly ILogger<RunAppJob> logger;

        private readonly IOptions<BotMenuConfig> botMenuOptions;

        public RunAppJob(
            IOptions<BotCredentialsConfig> botCredOptions, 
            ILogger<RunAppJob> logger,
            IOptions<BotMenuConfig> botMenuOptions)
        {
            this.botCredOptions = botCredOptions;
            this.logger = logger;
            this.botMenuOptions = botMenuOptions;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var botClient = await InitBotAsync();
            await SendMenuAsync(botClient);
        }

        public async Task SendMenuAsync(TelegramBotClient botClient)
        {
            var newCommands = botMenuOptions.Value.Commands.Select(x => new BotCommand { Command = x.Name, Description = x.Description });
            await botClient.SetMyCommandsAsync(newCommands);
        }

        private async Task<TelegramBotClient> InitBotAsync()
        {
            TelegramBotClient botClient = null;
            
            var botInited = false;

            while (!botInited)
            {
                botClient = await BotManager.GetBotClientAsync(botCredOptions);
                botInited = botClient != null;

                await Task.Delay(10 * 1000);
            }

            logger.LogInformation("Bot was inited");

            return botClient!;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
