using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotStorage;

namespace TelegramBotCommands.Commands.MenuCommands;

public class ChangeNativeLanguageTextCommand : BaseTextCommand
{
    public const string callBackId = "native_L-";

    public override string Name => CommandsNames.LanguageNative;

    public override async Task<TextInternalCommandResult> HandleTextInternalCommandAsync(Update update, FacadTelegramBotService service)
    {
        var res = new TextInternalCommandResult();

        var message = update.Message;

        var buttons = GetLanguagesButtons();

        InlineKeyboardMarkup inlineKeyboard = new(buttons);

        var botClient = await service.GetBotClientAsync();

        await botClient.SendTextMessageAsync(
            message.Chat.Id,
            $"Choose your native language",
            parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
            replyMarkup: inlineKeyboard
        );

        res.IsExecuted = true;
        return res;
    }

    public static IEnumerable<IEnumerable<InlineKeyboardButton>> GetLanguagesButtons()
    {
        return SupportedLanguages.GetLanguages().Chunk(2).Select(languages =>
        {
            return languages.Select(language =>
            {
                var name = language.Name;
                var languageCallbackData = callBackId + language.Id.ToString();

                return InlineKeyboardButton.WithCallbackData(text: language.Name, callbackData: languageCallbackData);
            });
        });
    }
}
