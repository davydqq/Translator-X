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

	public FacadTelegramBotService(MemoryStorage memoryStorage, IOptions<BotCredentialsConfig> config)
	{
		this.memoryStorage = memoryStorage;
		this.config = config;
	}

	public void AddOrUpdateUserNativeLanguage(long userId, LanguageENUM languageId)
	{
		memoryStorage.UserId_NativeLanguage.AddOrUpdate(userId, languageId, (key, oldValue) => languageId);
    }

    public void AddOrUpdateUserTargetLanguage(long userId, LanguageENUM languageId)
    {
        memoryStorage.UserId_TargetLanguage.AddOrUpdate(userId, languageId, (key, oldValue) => languageId);
    }

    public void AddOrUpdateUserSettedLanguage(long userId, bool setted)
    {
        memoryStorage.UserId_LangugageSetted.AddOrUpdate(userId, setted, (key, oldValue) => setted);
    }

    public bool IsLanguageSetted(long userId) => this.memoryStorage.UserId_LangugageSetted.GetValueOrDefault(userId);

    public bool LanguagesInited(long userId)
    {
        var nativeLang = memoryStorage.UserId_NativeLanguage.ContainsKey(userId);
        var targetLang = memoryStorage.UserId_TargetLanguage.ContainsKey(userId);
        return nativeLang && targetLang;
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
        var botClient = await GetBotClientAsync();
        await botClient.DeleteMessageAsync(chatId, messageId);
    }

    public Task<TelegramBotClient> GetBotClientAsync()
	{
        return BotManager.GetBotClientAsync(config);
    }


}
