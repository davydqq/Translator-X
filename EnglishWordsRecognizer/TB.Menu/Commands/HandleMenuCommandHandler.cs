using CQRS.Commands;
using Microsoft.Extensions.Options;
using TB.Core.Commands;
using TB.MemoryStorage;
using TB.MemoryStorage.Languages;
using TB.Menu.Entities;
using Telegram.Bot.Types.ReplyMarkups;

namespace TB.Menu.Commands;

public class HandleMenuCommandHandler : ICommandHandler<HandleMenuCommand>
{
	private readonly ICommandDispatcher commandDispatcher;

    private readonly Storage memoryStorage;

    private readonly IOptions<BotMenuConfig> menuOptions;

    public HandleMenuCommandHandler(
        ICommandDispatcher commandDispatcher,
        Storage memoryStorage,
        IOptions<BotMenuConfig> menuOptions)
	{
        this.commandDispatcher = commandDispatcher;
        this.memoryStorage = memoryStorage;
        this.menuOptions = menuOptions;
    }

	public async Task HandleAsync(HandleMenuCommand command, CancellationToken cancellation = default)
	{
        if (command.DeleteMessage)
        {
			await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, command.MessageId));
        }

        switch (command.MenuCommand.Id)
		{
			case BotMenuId.Start:
				{
                    memoryStorage.DeleteUserNativeLanguage(command.UserId);
                    memoryStorage.DeleteUserTargetLanguage(command.UserId);

                    var commandNL = menuOptions.Value.Commands.First(x => x.Id == BotMenuId.NativeLanguage);
                    var options = new HandleMenuCommand(commandNL, command.ChatId, command.MessageId, command.UserId, false);
                    await HandleAsync(options);
                    break;
				}
			case BotMenuId.NativeLanguage:
				{
                    var targetL = memoryStorage.GetUserTargetLanguage(command.UserId);
                    var message = $"Choose your native language";
                    var buttons = GetLanguagesButtons(command.MenuCommand.CallBackId, targetL);
                    InlineKeyboardMarkup inlineKeyboard = new(buttons);

                    var commandToSend = new SendMessageCommand(command.ChatId, message, null, inlineKeyboard);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
			case BotMenuId.TargetLanguage:
				{
                    var nativeL = memoryStorage.GetUserNativeLanguage(command.UserId);
                    var message = $"Choose target language";
                    var buttons = GetLanguagesButtons(command.MenuCommand.CallBackId, nativeL);
                    InlineKeyboardMarkup inlineKeyboard = new(buttons);

                    var commandToSend = new SendMessageCommand(command.ChatId, message, null, inlineKeyboard);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
				}
			case BotMenuId.Info:
				{
					var message = "Info";
					var commandToSend = new SendMessageCommand(command.ChatId, message);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
				}
            case BotMenuId.EnglishMeaning:
                {
                    var message = "English meaning has been ";
                    var messageToSend = "";
                    var isEnglishMeaningActive = memoryStorage.IsEnglishMeaningActive(command.UserId);
                    if (isEnglishMeaningActive)
                    {
                        memoryStorage.AddOrUpdateUserEnglishMeaning(command.UserId, false);
                        messageToSend = message + "disabled";
                    }
                    else
                    {
                        memoryStorage.AddOrUpdateUserEnglishMeaning(command.UserId, true);
                        messageToSend = message + "activated";
                    }
                    var commandToSend = new SendMessageCommand(command.ChatId, messageToSend);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
		}
	}

    public static IEnumerable<IEnumerable<InlineKeyboardButton>> GetLanguagesButtons(string callBackId, LanguageENUM? excludeLanguage)
    {
        return SupportedLanguages.GetLanguages().Where(x => x.Id != excludeLanguage).Chunk(2).Select(languages =>
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
