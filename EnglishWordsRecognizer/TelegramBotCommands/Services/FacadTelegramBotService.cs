using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TB.Core.Configs;
using Telegram.Bot.Types.Enums;
using TelegramBotImages;
using TelegramBotStorage;
using TelegramBotStorage.Languages;
using TelegramBotTranslator;

namespace TelegramBotCommands.Services;

public class FacadTelegramBotService
{
	private readonly MemoryStorage memoryStorage;

	private readonly IOptions<BotCredentialsConfig> config;

    public readonly ImageProcessService imageProcessService;

    public readonly TextProcessService textProcessService;

    private readonly ILogger<FacadTelegramBotService> logger;

    public FacadTelegramBotService(
        MemoryStorage memoryStorage, 
        IOptions<BotCredentialsConfig> config,
        ImageProcessService imageProcessService,
        TextProcessService textProcessService,
        ILogger<FacadTelegramBotService> logger)
	{
		this.memoryStorage = memoryStorage;
		this.config = config;
        this.imageProcessService = imageProcessService;
        this.textProcessService = textProcessService;
        this.logger = logger;
    }

	public void AddOrUpdateUserNativeLanguage(long userId, LanguageENUM languageId)
	{
		memoryStorage.UserId_NativeLanguage.AddOrUpdate(userId, languageId, (key, oldValue) => languageId);
    }

    public void AddOrUpdateUserTargetLanguage(long userId, LanguageENUM languageId)
    {
        memoryStorage.UserId_TargetLanguage.AddOrUpdate(userId, languageId, (key, oldValue) => languageId);
    }

    public void DeleteUserNativeLanguage(long userId)
    {
        memoryStorage.UserId_NativeLanguage.Remove(userId, out var language);
    }

    public void DeleteUserTargetLanguage(long userId)
    {
        memoryStorage.UserId_TargetLanguage.Remove(userId, out var language);
    }

    public LanguageENUM GetUserNativeLanguage(long userId)
    {
        return memoryStorage.UserId_NativeLanguage.GetValueOrDefault(userId);
    }

    public LanguageENUM GetUserTargetLanguage(long userId)
    {
        return memoryStorage.UserId_TargetLanguage.GetValueOrDefault(userId);
    }

    public List<Language> GetUserLanguages(long userId)
    {
        var languages = new List<Language>();

        if (memoryStorage.UserId_NativeLanguage.ContainsKey(userId))
        {
            var languageId = memoryStorage.UserId_NativeLanguage[userId];
            languages.Add(SupportedLanguages.languagesDict[languageId]);
        }

        if (memoryStorage.UserId_TargetLanguage.ContainsKey(userId))
        {
            var languageId = memoryStorage.UserId_TargetLanguage[userId];
            languages.Add(SupportedLanguages.languagesDict[languageId]);
        }

        return languages;
    }

    public bool IsNativeLanguageSetted(long userId) => memoryStorage.UserId_NativeLanguage.ContainsKey(userId);

    public bool IsTargetLanguageSetted(long userId) => memoryStorage.UserId_TargetLanguage.ContainsKey(userId);

    public bool LanguagesInited(long userId)
    {
        return IsNativeLanguageSetted(userId) && IsTargetLanguageSetted(userId);
    }

    public async Task SendLanguagesWereEstablished(long chatId, long userId)
    {
        await SendMessageAsync(chatId, $"The languages was established.\n" +
                                       $"You can send text, photo, audio for translating.\n" +
                                       $"Your languages \n" +
                                       $"Native Language: { SupportedLanguages.languagesDict[GetUserNativeLanguage(userId)].Name }\n" +
                                       $"Target Language: { SupportedLanguages.languagesDict[GetUserTargetLanguage(userId)].Name }"
                                , ParseMode.Html);
    }
}
