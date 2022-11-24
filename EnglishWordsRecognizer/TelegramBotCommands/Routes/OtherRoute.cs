using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;

namespace TelegramBotCommands.Commands
{
    public class OtherRoute : IBaseRoute
    {
        public int Order => int.MaxValue;

        public bool CanHandle(Update update)
        {
            return true;
        }

        public BaseRouteResult Execute(Update update)
        {
            var message = update.Message;
            var botClient = await service.GetBotClientAsync();
            await botClient.SendTextMessageAsync(
               message!.Chat.Id,
               $"Avaliable commands \n",
               parseMode: ParseMode.MarkdownV2
           );

            return new BaseCommandResult() { IsExecuted = true };
        }
    }
}
