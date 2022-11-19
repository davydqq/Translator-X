using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotManager;
using TelegramBotManager.Configs;
using TelegramBotStorage;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Services;

public class FacadTelegramBotService
{
	private readonly MemoryStorage memoryStorage;

	private readonly IOptions<BotCredentialsConfig> config;

    private readonly ILogger<FacadTelegramBotService> logger;

    public FacadTelegramBotService(MemoryStorage memoryStorage, IOptions<BotCredentialsConfig> config, ILogger<FacadTelegramBotService> logger)
	{
		this.memoryStorage = memoryStorage;
		this.config = config;
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

    public bool IsNativeLanguageSetted(long userId) => memoryStorage.UserId_NativeLanguage.ContainsKey(userId);

    public bool IsTargetLanguageSetted(long userId) => memoryStorage.UserId_TargetLanguage.ContainsKey(userId);

    public bool LanguagesInited(long userId)
    {
        return IsNativeLanguageSetted(userId) && IsTargetLanguageSetted(userId);
    }

    public async Task SendMessageAsync(long chatId, string message, ParseMode parseMode)
    {
        var botClient = await GetBotClientAsync();
        await botClient.SendTextMessageAsync(chatId, message, parseMode: parseMode);
    }

    public async Task SendMessageAsync(long chatId, string message, ParseMode parseMode, IReplyMarkup replyMarkup)
    {
        var botClient = await GetBotClientAsync();
        await botClient.SendTextMessageAsync(chatId, message, parseMode: parseMode, replyMarkup: replyMarkup);
    }

    public async Task DeleteMessageAsync(long chatId, int messageId)
    {
        try
        {
            var botClient = await GetBotClientAsync();
            await botClient.DeleteMessageAsync(chatId, messageId);
        } catch (Exception e)
        {
            logger.LogWarning("Message wasn`t been deleted");
        }
    }

    public Task<TelegramBotClient> GetBotClientAsync()
	{
        return BotManager.GetBotClientAsync(config);
    }

    //

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
