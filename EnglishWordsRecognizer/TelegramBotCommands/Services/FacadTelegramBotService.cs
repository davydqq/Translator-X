﻿using Microsoft.Extensions.Options;
using Telegram.Bot;
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

    public Task<TelegramBotClient> GetBotClientAsync()
	{
        return BotManager.GetBotClientAsync(config);
    }


}
