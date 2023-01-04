using CQRS.Commands;
using Microsoft.Extensions.Options;
using TB.Core.Commands;
using TB.Database.Entities;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.Menu.Commands;
using TB.Menu.Entities;
using Telegram.Bot.Types.Enums;

namespace TB.Callbacks.Commands;

public class HandleCallbackCommandHandler : ICommandHandler<HandleCallbackCommand, bool>
{
    private readonly IOptions<BotMenuConfig> options;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly UserSettingsRepository userSettingsRepository;

    private readonly ILocalizationService localizationService;

    public HandleCallbackCommandHandler(
        IOptions<BotMenuConfig> options, 
        ICommandDispatcher commandDispatcher,
        UserSettingsRepository userSettingsRepository,
        ILocalizationService localizationService)
    {
        this.options = options;
        this.commandDispatcher = commandDispatcher;
        this.userSettingsRepository = userSettingsRepository;
        this.localizationService = localizationService;
    }

    public async Task<bool> HandleAsync(HandleCallbackCommand command, CancellationToken cancellation = default)
    {
        var callbackId = GetCallbackId(command.Data);
        var menuCommand = options.Value.Commands.FirstOrDefault(x => x.CallBackId == callbackId);

        if(menuCommand != null)
        {
            switch (menuCommand.Id)
            {
                case BotMenuId.NativeLanguage:
                    {
                        await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, command.MessageId));

                        var settings = await userSettingsRepository.GetSettingsIncludeTargetNativeLanguagesAsync(command.UserId);

                        var language = GetLanguage(command.Data!);
                        if (language.HasValue)
                        {
                            settings.NativeLanguageId = language;
                            await userSettingsRepository.UpdateAsync(settings);
                        }

                        await SendLanguagesWereEstablished(command.ChatId, command.UserId);

                        if (settings.TargetLanguageId == null)
                        {
                            var nativeLanguageOption = options.Value.Commands.First(x => x.Id == BotMenuId.TargetLanguage);
                            var menuCommandNativeLangauge = new HandleMenuCommand(nativeLanguageOption, command.ChatId, command.MessageId, command.UserId, false, command.Update);

                            await commandDispatcher.DispatchAsync(menuCommandNativeLangauge);
                        }

                        break;
                    }
                case BotMenuId.TargetLanguage:
                    {
                        await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, command.MessageId));

                        var settings = await userSettingsRepository.GetSettingsIncludeTargetNativeLanguagesAsync(command.UserId);

                        var language = GetLanguage(command.Data!);
                        if (language.HasValue)
                        {
                            settings.TargetLanguageId = language;
                            await userSettingsRepository.UpdateAsync(settings);
                        }

                        await SendLanguagesWereEstablished(command.ChatId, command.UserId);

                        if (settings.NativeLanguageId == null)
                        {
                            var nativeLanguageOption = options.Value.Commands.First(x => x.Id == BotMenuId.NativeLanguage);
                            var menuCommandNativeLangauge = new HandleMenuCommand(nativeLanguageOption, command.ChatId, command.MessageId, command.UserId, false, command.Update);
                            
                            await commandDispatcher.DispatchAsync(menuCommandNativeLangauge);
                        }

                        break;
                    }
                case BotMenuId.IntefaceLanguage:
                    {
                        await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, command.MessageId));

                        var settings = await userSettingsRepository.GetSettingsIncludeTargetNativeLanguagesAsync(command.UserId);

                        var language = GetLanguage(command.Data!);
                        if (language.HasValue)
                        {
                            settings.InterfaceLanguageId = language;
                            await userSettingsRepository.UpdateAsync(settings);
                        }

                        await SendIntefaceLanguageEstablished(command.ChatId, command.UserId);
                        break;
                    }
                case BotMenuId.AudioTranscriptionLanguage:
                    {
                        await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, command.MessageId));

                        var settings = await userSettingsRepository.GetSettingsIncludeTargetNativeLanguagesAsync(command.UserId);

                        var language = GetLanguage(command.Data!);
                        if (language.HasValue)
                        {
                            settings.AudioLanguageId = language;
                            await userSettingsRepository.UpdateAsync(settings);
                        }

                        await SendAudioLanguageEstablished(command.ChatId, command.UserId);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        return true;
    }

    public async Task SendAudioLanguageEstablished(long chatId, long userId)
    {
        var settings = await userSettingsRepository.GetAudioLanguageAsync(userId);

        var baseMessage = await localizationService.GetTranslateByInterface("app.languages.audioLanguageKey", userId);
        var message = $"{baseMessage} {settings.AudioLanguage.Name}";

        var commandMessage = new SendMessageCommand(chatId, message, ParseMode.Html);

        await commandDispatcher.DispatchAsync(commandMessage);
    }

    public async Task SendIntefaceLanguageEstablished(long chatId, long userId)
    {
        var settings = await userSettingsRepository.GetLanguageInterfaceAsync(userId);

        var baseMessage = await localizationService.GetTranslateByInterface("app.languages.interfaceLanguage", userId);
        var message = $"{baseMessage} {settings.InterfaceLanguage.Name}";

        var commandMessage = new SendMessageCommand(chatId, message, ParseMode.Html);

        await commandDispatcher.DispatchAsync(commandMessage);
    }

    public async Task SendLanguagesWereEstablished(long chatId, long userId)
    {
        var isLanguagesInited = await userSettingsRepository.GetAnyAsync(x => x.TelegramUserId == userId && x.NativeLanguageId != null && x.TargetLanguageId != null);
        if (isLanguagesInited)
        {
            var settings = await userSettingsRepository.GetSettingsIncludeTargetNativeLanguagesAsync(userId);
            var nativeLanguage = settings.NativeLanguage;
            var targetLanguage = settings.TargetLanguage;

            var messageEstablished = await localizationService.GetTranslateByInterface("app.languages.established", userId);
            var messageLanguages = await localizationService.GetTranslateByInterface("app.languages.yourLanguages", userId);

            var messageTargetLanguage = await localizationService.GetTranslateByInterface("app.languages.targetL", userId);
            var messageNativeLanguage = await localizationService.GetTranslateByInterface("app.languages.nativeL", userId);

            var messageCanSend = await localizationService.GetTranslateByInterface("app.languages.canSend", userId);

            var message = $"{messageEstablished}\n" +
                          $"{messageCanSend}\n" +
                          $"{messageLanguages} \n" +
                          $"{messageNativeLanguage} {nativeLanguage.Name}\n" +
                          $"{messageTargetLanguage} {targetLanguage.Name}";

            var command = new SendMessageCommand(chatId, message, ParseMode.Html);

            await commandDispatcher.DispatchAsync(command);
        }
    }

    private string GetCallbackId(string data)
    {
        var id = data.Split("-").ElementAt(0);
        return id + "-";
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
