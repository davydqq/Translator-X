using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotCommands.Services;
using TelegramBotStorage;

namespace TelegramBotCommands.Commands;

public class StartTextCommand : BaseTextCommand
{
    public override string Name => CommandsNames.Start;

    public override async Task HandleTextCommand(Message message, FacadTelegramBotService service)
    {
        var buttons = SupportedLanguages.GetLanguagesButtons();

        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            buttons
        });

        var botClient = await service.GetBotClientAsync();

        await botClient.SendTextMessageAsync(
            message.Chat.Id,
            $"Hi, {message.Chat.FirstName} \n Choose your native language :",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
            replyMarkup: inlineKeyboard
        );
    }
}
