using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;

namespace TelegramBotCommands.Commands
{
    public class OtherCommand : BaseCommand
    {
        public override int Order => int.MaxValue;

        public override bool CanHandle(Update update)
        {
            if (update.Message == null || update.Message.Chat == null)
                return false;

            return true;
        }

        public override async Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
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
