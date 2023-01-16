using CQRS.Commands;
using Microsoft.Extensions.Options;
using System.Numerics;
using TB.BillingPlans;
using TB.Common;
using TB.Core.Commands;
using TB.Database.Entities;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.Menu.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TB.Menu.Commands;

public class HandleMenuCommandHandler : ICommandHandler<HandleMenuCommand, bool>
{
	private readonly ICommandDispatcher commandDispatcher;

    private readonly IOptions<BotMenuConfig> menuOptions;

    private readonly UserSettingsRepository userSettingsRepository;

    private readonly IRepository<Language, LanguageENUM> languageRepository;

    private readonly ILocalizationService localizationService;

    private readonly IBillingPlanService billingPlanService;

    private readonly PlanCacheRepository planCacheRepository;

    public HandleMenuCommandHandler(
        ICommandDispatcher commandDispatcher,
        IOptions<BotMenuConfig> menuOptions,
        UserSettingsRepository userSettingsRepository,
        IRepository<Language, LanguageENUM> languageRepository,
        ILocalizationService localizationService,
        IBillingPlanService billingPlanService,
        PlanCacheRepository planCacheRepository)
	{
        this.commandDispatcher = commandDispatcher;
        this.menuOptions = menuOptions;
        this.userSettingsRepository = userSettingsRepository;
        this.languageRepository = languageRepository;
        this.localizationService = localizationService;
        this.billingPlanService = billingPlanService;
        this.planCacheRepository = planCacheRepository;
    }

	public async Task<bool> HandleAsync(HandleMenuCommand command, CancellationToken cancellation = default)
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
                    var options = new HandleMenuCommand(commandNL, command.ChatId, command.MessageId, command.UserId, false, command.Update);
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
			case BotMenuId.BotInfo:
				{
					var message = await localizationService.GetTranslateByInterface("app.menu.info", command.UserId);
					var commandToSend = new SendMessageCommand(command.ChatId, message, ParseMode.Html);
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
            case BotMenuId.AudioTranscriptionLanguage:
                {
                    var message = await localizationService.GetTranslateByInterface("app.menu.audioLang", command.UserId);
                    var langs = await languageRepository.GetWhereAsync(x => x.IsSupportAudioTranscription);
                    var buttons = GetLanguagesButtons(command.MenuCommand.CallBackId, langs);
                    InlineKeyboardMarkup inlineKeyboard = new(buttons);

                    var commandToSend = new SendMessageCommand(command.ChatId, message, null, inlineKeyboard);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
            case BotMenuId.Stats:
                {
                    var imageRequests = await billingPlanService.GetPaidPlanImageRequestsAsync(command.UserId);
                    var imageCount = imageRequests.request.Count;

                    var audioRequests = await billingPlanService.GetPaidPlanAudioRequestAsync(command.UserId);
                    var audioTotalSeconds = audioRequests.request.Count == 0 ? 0 : audioRequests.request.Sum(x => x.ProcessedSeconds);
                    var audioTotalMinutes = (double)audioTotalSeconds / 60;

                    var textRequests = await billingPlanService.GetPaidPlanTextRequestAsync(command.UserId);
                    var textChars = textRequests.request.Count == 0 ? 0 : textRequests.request.Sum(x => x.TotalChars);

                    var userPlan = imageRequests.plan;
                    var plan = planCacheRepository.GetByKeyOrDefault(imageRequests.plan.PlanId);

                    var message = await localizationService.GetTranslateByInterface("stats.message", command.UserId);

                    var timeDifference = userPlan.ExpireDate - TimeProvider.Get();

                    var planAudioMinutes = Math.Round((double)plan.MaxAudioTranscriptionSecondsMonth / 60, 2);

                    var formatedMessage = string.Format(message, 
                                            plan.Name, 
                                            imageCount, plan.MaxAnalysisPhotoCountMonth,
                                            textChars, plan.MaxTranslateCharsMonth,
                                            Math.Round(audioTotalMinutes, 2), planAudioMinutes,
                                            Math.Round(timeDifference.TotalDays, 1),
                                            Math.Round(timeDifference.TotalHours, 1));

                    var commandToSend = new SendMessageCommand(command.ChatId, formatedMessage, ParseMode.Html);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
            case BotMenuId.UserInfo:
                {
                    var userSettings = await userSettingsRepository.FirstOrDefaultAsync(x => x.TelegramUserId == command.UserId);
                    var languages = (await languageRepository.GetAllAsync()).ToDictionary(x => x.Id);

                    string LangExist(LanguageENUM? language)
                    {
                        if(language != null && languages.ContainsKey(language.Value))
                        {
                            return languages[language.Value].Name;
                        }

                        return "No сhosen";
                    }

                    var meaningKey = userSettings.RecognizeEnglishMeaning ? "app.menu.activated" : "app.menu.disabled";
                    var meaningDescription = await localizationService.GetTranslateByInterface(meaningKey, command.UserId);


                    var infoMessage = await localizationService.GetTranslateByInterface("app.menu.userInfo", command.UserId);
                    var formatedMessage = string.Format(infoMessage,
                                          LangExist(userSettings.NativeLanguageId),
                                          LangExist(userSettings.TargetLanguageId),
                                          LangExist(userSettings.AudioLanguageId),
                                          LangExist(userSettings.InterfaceLanguageId),
                                          meaningDescription);

                    var commandToSend = new SendMessageCommand(command.ChatId, formatedMessage, ParseMode.Html);
                    await commandDispatcher.DispatchAsync(commandToSend);
                    break;
                }
		}

        return true;
	}

    public IEnumerable<IEnumerable<InlineKeyboardButton>> GetLanguagesButtons(
        string callBackId, List<Language> langs)
    {
        return langs.Chunk(2).Select(languages =>
        {
            return languages.Select(language =>
            {
                var languageCallbackData = callBackId + language.Id.ToString();
                return InlineKeyboardButton.WithCallbackData(text: language.Name, callbackData: languageCallbackData);
            });
        });
    }
}
