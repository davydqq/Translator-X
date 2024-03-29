﻿using Microsoft.Extensions.Options;
using TB.Core.Configs;
using TB.Menu.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TB.API.Jobs
{
    public class RunAppJob : IHostedService
    {
        private readonly IOptions<BotCredentialsConfig> botCredOptions;

        private readonly ILogger<RunAppJob> logger;

        private readonly IOptions<BotMenuConfig> botMenuOptions;

        private readonly TelegramBotClient telegramBotClient;

        public RunAppJob(
            IOptions<BotCredentialsConfig> botCredOptions,
            ILogger<RunAppJob> logger,
            IOptions<BotMenuConfig> botMenuOptions,
            TelegramBotClient telegramBotClient)
        {
            this.botCredOptions = botCredOptions;
            this.logger = logger;
            this.botMenuOptions = botMenuOptions;
            this.telegramBotClient = telegramBotClient;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await InitBotAsync();
            await SendMenuAsync(telegramBotClient);
        }

        public async Task SendMenuAsync(TelegramBotClient botClient)
        {
            var newCommands = botMenuOptions.Value.Commands.OrderBy(x => x.Order).Select(x => new BotCommand { Command = x.Name, Description = x.Description });
            await botClient.SetMyCommandsAsync(newCommands);
        }

        private async Task InitBotAsync()
        {
            await telegramBotClient.SetWebhookAsync(botCredOptions.Value.Url);

            logger.LogInformation("WebHook was setted");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
