using CQRS.Commands;
using TB.Core.Commands;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotStorage;

namespace TB.Menu.Commands;

public class SendMenuCommandHandler : ICommandHandler<SendMenuCommand>
{
	private readonly ICommandDispatcher commandDispatcher;

    private readonly MemoryStorage memoryStorage;

	public SendMenuCommandHandler(ICommandDispatcher commandDispatcher, MemoryStorage memoryStorage)
	{
        this.commandDispatcher = commandDispatcher;
        this.memoryStorage = memoryStorage;
	}

	public async Task HandleAsync(SendMenuCommand command, CancellationToken cancellation = default)
	{
        if (command.DeleteMessage)
        {
			await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, command.MessageId));
        }

        switch (command.BotMenuId)
		{
			case BotMenuId.Start:
				{
                    memoryStorage.DeleteUserNativeLanguage(command.UserId);
                    memoryStorage.DeleteUserTargetLanguage(command.UserId);

                    var options = new SendMenuCommand(BotMenuId.NativeLanguage, command.ChatId, command.MessageId, command.UserId, false);
                    await HandleAsync(options);
                    break;
				}
			case BotMenuId.NativeLanguage:
				{
                    var callBackId = "native_L-";
                    var message = $"Choose your native language";
                    var buttons = GetLanguagesButtons(callBackId);
                    InlineKeyboardMarkup inlineKeyboard = new(buttons);

                    var commandToSend = new SendMessageCommand(command.ChatId, message, null, inlineKeyboard);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
			case BotMenuId.TargetLanguage:
				{
                    var callBackId = "target_L-";
                    var message = $"Choose target language";
                    var buttons = GetLanguagesButtons(callBackId);
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
