using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TB.ComputerVision;
using TB.Core.Configs;
using Telegram.Bot.Types.Enums;
using TelegramBotStorage;
using TelegramBotStorage.Languages;
using TelegramBotTranslator;

namespace TelegramBotCommands.Services;

public class FacadTelegramBotService
{
	private readonly IOptions<BotCredentialsConfig> config;

    public readonly AzureComputerVisionService imageProcessService;

    public readonly TextProcessService textProcessService;

    private readonly ILogger<FacadTelegramBotService> logger;

    public FacadTelegramBotService(
        IOptions<BotCredentialsConfig> config,
        AzureComputerVisionService imageProcessService,
        TextProcessService textProcessService,
        ILogger<FacadTelegramBotService> logger)
	{
		this.config = config;
        this.imageProcessService = imageProcessService;
        this.textProcessService = textProcessService;
        this.logger = logger;
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
