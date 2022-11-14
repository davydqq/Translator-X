using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotCommands.Services;
using TelegramBotStorage;

namespace TelegramBotCommands.Commands;

public class LanguageTextCommand : BaseTextCommand
{
    public override string Name => CommandsNames.Language;

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
            $"Hi, {message.Chat.FirstName} \n<h1>Choose your native language</h1>",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
            replyMarkup: inlineKeyboard
        );
    }
}
