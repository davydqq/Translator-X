using CQRS.Commands;
using Microsoft.Extensions.Options;
using TB.Core.Commands;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotStorage;

namespace TB.Menu.Commands;

public class HandleMenuCommandHandler : ICommandHandler<HandleMenuCommand>
{
	private readonly ICommandDispatcher commandDispatcher;

    private readonly MemoryStorage memoryStorage;

    private readonly IOptions<BotMenuConfig> menuOptions;

    public HandleMenuCommandHandler(
        ICommandDispatcher commandDispatcher, 
        MemoryStorage memoryStorage,
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
                    var message = $"Choose your native language";
                    var buttons = GetLanguagesButtons(command.MenuCommand.CallBackId);
                    InlineKeyboardMarkup inlineKeyboard = new(buttons);

                    var commandToSend = new SendMessageCommand(command.ChatId, message, null, inlineKeyboard);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
			case BotMenuId.TargetLanguage:
				{
                    var message = $"Choose target language";
                    var buttons = GetLanguagesButtons(command.MenuCommand.CallBackId);
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
		}
	}

    public static IEnumerable<IEnumerable<InlineKeyboardButton>> GetLanguagesButtons(string callBackId)
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
