using CQRS.Commands;
using Microsoft.Extensions.Options;
using TB.Core.Commands;
using TB.Menu.Commands;
using TB.Menu.Entities;
using Telegram.Bot.Types.Enums;
using TelegramBotStorage;
using TelegramBotStorage.Languages;

namespace TB.Callbacks.Commands;

public class HandleCallbackCommandHandler : ICommandHandler<HandleCallbackCommand>
{
    private readonly IOptions<BotMenuConfig> options;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly MemoryStorage memoryStorage;

    public HandleCallbackCommandHandler(
        IOptions<BotMenuConfig> options, 
        ICommandDispatcher commandDispatcher,
        MemoryStorage memoryStorage)
    {
        this.options = options;
        this.commandDispatcher = commandDispatcher;
        this.memoryStorage = memoryStorage;
    }

    public async Task HandleAsync(HandleCallbackCommand command, CancellationToken cancellation = default)
    {
        var menuCommand = options.Value.Commands.FirstOrDefault(x => x.CallBackId == command.Data);

        if(menuCommand != null)
        {
            switch (menuCommand.Id)
            {
                case BotMenuId.NativeLanguage:
                    {
                        await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, command.MessageId));

                        var language = GetLanguage(command.Data!);
                        if (language.HasValue)
                        {
                            memoryStorage.AddOrUpdateUserNativeLanguage(command.UserId, language.Value);
                        }

                        await SendLanguagesWereEstablished(command.ChatId, command.UserId);

                        if (!memoryStorage.IsTargetLanguageSetted(command.UserId))
                        {
                            var nativeLanguageOption = options.Value.Commands.First(x => x.Id == BotMenuId.TargetLanguage);
                            var menuCommandNativeLangauge = new HandleMenuCommand(nativeLanguageOption, command.ChatId, command.MessageId, command.UserId, false);

                            await commandDispatcher.DispatchAsync(menuCommandNativeLangauge);
                        }

                        break;
                    }
                case BotMenuId.TargetLanguage:
                    {
                        await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, command.MessageId));

                        var language = GetLanguage(command.Data!);
                        if (language.HasValue)
                        {
                            memoryStorage.AddOrUpdateUserTargetLanguage(command.UserId, language.Value);
                        }

                        await SendLanguagesWereEstablished(command.ChatId, command.UserId);

                        if (!memoryStorage.IsNativeLanguageSetted(command.UserId))
                        {
                            var nativeLanguageOption = options.Value.Commands.First(x => x.Id == BotMenuId.NativeLanguage);
                            var menuCommandNativeLangauge = new HandleMenuCommand(nativeLanguageOption, command.ChatId, command.MessageId, command.UserId, false);
                            
                            await commandDispatcher.DispatchAsync(menuCommandNativeLangauge);
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

    public async Task SendLanguagesWereEstablished(long chatId, long userId)
    {
        if (memoryStorage.LanguagesInited(userId))
        {
            var nativeLanguage = SupportedLanguages.languagesDict[memoryStorage.GetUserNativeLanguage(userId)].Name;
            var targetLanguage = SupportedLanguages.languagesDict[memoryStorage.GetUserTargetLanguage(userId)].Name;

            var message = $"The languages was established.\n" +
                          $"You can send text, photo, audio for translating.\n" +
                          $"Your languages \n" +
                          $"Native Language: {nativeLanguage}\n" +
                          $"Target Language: {targetLanguage}";

            var command = new SendMessageCommand(chatId, message, ParseMode.Html);

            await commandDispatcher.DispatchAsync(command);
        }
    }

    private LanguageENUM? GetLanguage(string data)
    {
        var id = data.Split("-").ElementAt(1);
        if (Enum.TryParse(id, out LanguageENUM lang))
        {
            return lang;
        }

        return null;
    }
}
