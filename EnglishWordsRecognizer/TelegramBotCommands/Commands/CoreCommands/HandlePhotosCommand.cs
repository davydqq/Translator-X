using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Commands.CoreCommands;

public class HandlePhotosCommand : BaseCommand
{
	public HandlePhotosCommand()
	{

	}

	public override int Order => 15;

	public override bool CanHandle(Update update)
	{
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;

        if (message.Type != MessageType.Photo)
            return false;

        return true;
    }

	public async override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
	{
        var chatId = update.Message.Chat.Id;
        var userId = update.Message.From.Id;

        // TODO add validation accepted types;

        var bot = await service.GetBotClientAsync();
        var photos = update.Message.Photo;
        var maxPhoto = photos.MaxBy(x => x.FileSize);

        var bytes = await service.DownloadFileAsync(maxPhoto.FileId);

        var resAnalys = await service.imageProcessService.AnalyzeImage(bytes);
        await ProcessAndSendOCRResultsAsync(service, bytes, chatId);
        await ProcessAndSendPhotoAnalysisAsync(service, bytes, chatId, userId);

        return new BaseCommandResult();
	}

    private async Task<bool> ProcessAndSendPhotoAnalysisAsync(FacadTelegramBotService service, byte[] bytes, long chatId, long userId)
    {
        var results = await service.imageProcessService.AnalyzeImage(bytes);

        if(results != null)
        {
            var resText = "";

            var tags = results.Tags?.Select(x => x.Name) ?? new List<string>();
            var descriptionTags = results.Description?.Tags ?? new List<string>();

            var resTags = tags.Union(descriptionTags).Distinct();

            if (resTags != null && resTags.Any())
            {
                var languagesToTranslate = service.GetUserLanguages(userId)
                                                   .Where(x => x.Id != LanguageENUM.English)
                                                   .Select(x => x.Code).ToArray();
                // TODO 1. HANDLE WHEN NO LANGUAGES
                // 1. output
                var resp = await service.textProcessService.ProcessTextAsync(resTags.ToArray(), languagesToTranslate);

                var text = "Photo objects\n\n";
                text += string.Join("\n", resTags);

                resText += text;
            }

            if(results.Description != null)
            {
                var captions = results.Description.Captions.Select(x => x.Text);

                var text = "\nPhoto description\n\n";
                text += string.Join("\n", captions);
                resText += text;
            }

            if (!string.IsNullOrEmpty(resText))
            {
                await service.SendMessageAsync(chatId, resText, ParseMode.Markdown);
            }
        }

        return false;
    }

    private async Task<bool> ProcessAndSendOCRResultsAsync(FacadTelegramBotService service, byte[] bytes, long chatId)
    {
        var results = await service.imageProcessService.OCRImage(bytes);
        if (results != null && results.Count > 0)
        {
            var text = "Text on photo\n\n";
            var texts = string.Join("\n", results.SelectMany(x => x.Lines).Select(x => x.Text));

            if (!string.IsNullOrEmpty(texts))
            {
                text += texts;
                await service.SendMessageAsync(chatId, text, ParseMode.Markdown);

                return true;
            }
        }

        return false;
    }

}
