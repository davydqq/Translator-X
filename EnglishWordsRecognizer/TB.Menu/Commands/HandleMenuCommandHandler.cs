using CQRS.Commands;
using Microsoft.Extensions.Options;
using TB.Core.Commands;
using TB.Database.Entities;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.Menu.Entities;
using Telegram.Bot.Types.ReplyMarkups;

namespace TB.Menu.Commands;

public class HandleMenuCommandHandler : ICommandHandler<HandleMenuCommand>
{
	private readonly ICommandDispatcher commandDispatcher;

    private readonly IOptions<BotMenuConfig> menuOptions;

    private readonly UserSettingsRepository userSettingsRepository;

    private readonly IRepository<Language, LanguageENUM> languageRepository;

    private readonly ILocalizationService localizationService;

    public HandleMenuCommandHandler(
        ICommandDispatcher commandDispatcher,
        IOptions<BotMenuConfig> menuOptions,
        UserSettingsRepository userSettingsRepository,
        IRepository<Language, LanguageENUM> languageRepository,
        ILocalizationService localizationService)
	{
        this.commandDispatcher = commandDispatcher;
        this.menuOptions = menuOptions;
        this.userSettingsRepository = userSettingsRepository;
        this.languageRepository = languageRepository;
        this.localizationService = localizationService;
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
                    var settings = await userSettingsRepository.FirstOrDefaultAsync(x => x.TelegramUserId == command.UserId);
                    if(settings != null)
                    {
                        settings.TargetLanguageId = null;
                        settings.NativeLanguageId = null;
                        await userSettingsRepository.UpdateAsync(settings);
                    }

                    var commandNL = menuOptions.Value.Commands.First(x => x.Id == BotMenuId.NativeLanguage);
                    var options = new HandleMenuCommand(commandNL, command.ChatId, command.MessageId, command.UserId, false);
                    await HandleAsync(options);
                    break;
				}
			case BotMenuId.NativeLanguage:
				{
                    var settings = await userSettingsRepository.FirstOrDefaultAsync(x => x.TelegramUserId == command.UserId);
                    var targetL = settings.TargetLanguageId;
                    var langs = await languageRepository.GetWhereAsync(x => x.Id != targetL && x.IsSupportNativeLanguage);
                    var message = await localizationService.GetTranslateByInterface("app.menu.chooseNative", command.UserId);
                    var buttons = GetLanguagesButtons(command.MenuCommand.CallBackId, langs);
                    InlineKeyboardMarkup inlineKeyboard = new(buttons);

                    var commandToSend = new SendMessageCommand(command.ChatId, message, null, inlineKeyboard);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
			case BotMenuId.TargetLanguage:
				{
                    var settings = await userSettingsRepository.FirstOrDefaultAsync(x => x.TelegramUserId == command.UserId);
                    var nativeL = settings.NativeLanguageId;
                    var message = await localizationService.GetTranslateByInterface("app.menu.chooseTarget", command.UserId);
                    var langs = await languageRepository.GetWhereAsync(x => x.Id != nativeL && x.IsSupportTargetLanguage);
                    var buttons = GetLanguagesButtons(command.MenuCommand.CallBackId, langs);
                    InlineKeyboardMarkup inlineKeyboard = new(buttons);

                    var commandToSend = new SendMessageCommand(command.ChatId, message, null, inlineKeyboard);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
				}
			case BotMenuId.Info:
				{
					var message = await localizationService.GetTranslateByInterface("app.menu.info", command.UserId);
					var commandToSend = new SendMessageCommand(command.ChatId, message);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
				}
            case BotMenuId.EnglishMeaning:
                {
                    var message = (await localizationService.GetTranslateByInterface("app.menu.englishMeaning", command.UserId)) + " ";
                    var messageToSend = "";
                    var settings = await userSettingsRepository.FirstOrDefaultAsync(x => x.TelegramUserId == command.UserId);
                    if (settings.RecognizeEnglishMeaning)
                    {
                        settings.RecognizeEnglishMeaning = false;
                        await userSettingsRepository.UpdateAsync(settings);
                        messageToSend = message + await localizationService.GetTranslateByInterface("app.menu.disabled", command.UserId);
                    }
                    else
                    {
                        settings.RecognizeEnglishMeaning = true;
                        await userSettingsRepository.UpdateAsync(settings);
                        messageToSend = message + await localizationService.GetTranslateByInterface("app.menu.activated", command.UserId);
                    }
                    var commandToSend = new SendMessageCommand(command.ChatId, messageToSend);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
            case BotMenuId.IntefaceLanguage:
                {
                    var settings = await userSettingsRepository.FirstOrDefaultAsync(x => x.TelegramUserId == command.UserId);
                    var interfaceLanguage = settings.InterfaceLanguageId;
                    var message = await localizationService.GetTranslateByInterface("app.menu.chooseLang", command.UserId);
                    var langs = await languageRepository.GetWhereAsync(x => x.Id != interfaceLanguage && x.IsSupportInteface);
                    var buttons = GetLanguagesButtons(command.MenuCommand.CallBackId, langs);
                    InlineKeyboardMarkup inlineKeyboard = new(buttons);

                    var commandToSend = new SendMessageCommand(command.ChatId, message, null, inlineKeyboard);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
		}
	}

    public IEnumerable<IEnumerable<InlineKeyboardButton>> GetLanguagesButtons(
        string callBackId, List<Language> langs)
    {
        return langs.Chunk(2).Select(languages =>
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
