using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;

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

        // TODO add validation accepted types;

        var bot = await service.GetBotClientAsync();
        var photos = update.Message.Photo;
        var maxPhoto = photos.MaxBy(x => x.FileSize);

        var bytes = await service.DownloadFileAsync(maxPhoto.FileId);

        var resAnalys = await service.imageProcessService.AnalyzeImage(bytes);
        await ProcessAndSendOCRResultsAsync(service, bytes, chatId);

        return new BaseCommandResult();
	}

    private async Task<bool> ProcessAndSendPhotoAnalysisAsync(FacadTelegramBotService service, byte[] bytes, long chatId)
    {
        var results = await service.imageProcessService.AnalyzeImage(bytes);

        if(results != null)
        {
            var tags = results.Tags.Select(x => x.Name);

            if (tags != null && tags.Any())
            {
                var text = "Photo objects\n\n";
                text += string.Join("\n", tags);

                await service.SendMessageAsync(chatId, text, ParseMode.Markdown);

                return true;
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
