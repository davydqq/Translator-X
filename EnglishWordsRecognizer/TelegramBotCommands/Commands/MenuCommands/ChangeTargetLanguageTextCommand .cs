using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotCommands.Services;
using TelegramBotStorage;

namespace TelegramBotCommands.Commands.MenuCommands;

public class ChangeTargetLanguageTextCommand : BaseTextCommand
{
    public const string callBackId = "target_L-";

    public override string Name => CommandsNames.LanguageTarget;

    public override async Task HandleTextCommandAsync(Update update, FacadTelegramBotService service)
    {
        var buttons = GetLanguagesButtons();

        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            buttons
        });

        var botClient = await service.GetBotClientAsync();

        await botClient.SendTextMessageAsync(
            update.Message.Chat.Id,
            $"Choose target language",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
            replyMarkup: inlineKeyboard
        );
    }

    public static IEnumerable<InlineKeyboardButton> GetLanguagesButtons()
    {
        return SupportedLanguages.GetLanguages().Select(language =>
        {
            var name = language.Name;
            var languageCallbackData = callBackId + language.Id.ToString();

            return InlineKeyboardButton.WithCallbackData(text: language.Name, callbackData: languageCallbackData);
        });
    }
}
