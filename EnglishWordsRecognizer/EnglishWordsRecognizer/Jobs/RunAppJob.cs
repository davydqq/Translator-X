using Microsoft.Extensions.Options;
using TelegramBotManager;

namespace EnglishWordsRecognizer.Jobs
{
    public class RunAppJob : IHostedService
    {
        private readonly IOptions<BotConfig> options;
        private readonly ILogger<RunAppJob> logger;

        public RunAppJob(IOptions<BotConfig> options, ILogger<RunAppJob> logger)
        {
            this.options = options;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var botInited = false;

            while (!botInited)
            {
                var botClient = BotManager.GetBotClientAsync(options);
                botInited = botClient != null;

                await Task.Delay(10 * 1000);
            }

            logger.LogInformation("Bot was inited");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
