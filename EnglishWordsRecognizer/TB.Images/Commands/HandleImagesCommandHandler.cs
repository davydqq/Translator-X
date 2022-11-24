using CQRS.Commands;
using CQRS.Queries;
using Microsoft.Extensions.Logging;
using TB.ComputerVision;
using TB.Core.Queries;

namespace TB.Images.Commands;

public class HandleImagesCommandHandler : ICommandHandler<HandleImagesCommand>
{
    private readonly ILogger<HandleImagesCommandHandler> logger;
    private readonly IComputerVisionService computerVisionService;
    private readonly IQueryDispatcher queryDispatcher;

    public HandleImagesCommandHandler(
        ILogger<HandleImagesCommandHandler> logger, 
        IComputerVisionService computerVisionService,
        IQueryDispatcher queryDispatcher)
    {
        this.logger = logger;
        this.computerVisionService = computerVisionService;
        this.queryDispatcher = queryDispatcher;
    }

    public async Task HandleAsync(HandleImagesCommand command, CancellationToken cancellation = default)
    {
        // TODO add validation accepted types;

        var file = command.Files.MaxBy(x => x.Size);

        var bytes =  await queryDispatcher.DispatchAsync(new DownloadFileQuery(file.TelegramFileId));

        await ProcessAndSendOCRResultsAsync(bytes, command.ChatId, command.UserId);
        await ProcessAndSendPhotoAnalysisAsync(bytes, command.ChatId, command.UserId);
    }

    private async Task<bool> ProcessAndSendPhotoAnalysisAsync(byte[] bytes, long chatId, long userId)
    {
        var results = await computerVisionService.AnalyzeImageAsync(bytes);

        if (results != null)
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

            if (results.Description != null)
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

    private async Task<bool> ProcessAndSendOCRResultsAsync(byte[] bytes, long chatId, long userId)
    {
        var results = await computerVisionService.OCRImageAsync(bytes);

        if (results != null && results.TextResults.Count > 0)
        {
            var text = "Text on photo\n\n";
            var texts = string.Join("\n", results.TextResults.SelectMany(x => x.Lines).Select(x => x.Text));

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
