using CQRS.Queries;
using Microsoft.Extensions.Logging;
using TB.Core.Entities;
using Telegram.Bot;

namespace TB.Core.Queries;

public class DownloadFileQueryHandler : IQueryHandler<DownloadFileQuery, DownloadFileResult>
{
    private readonly TelegramBotClient telegramBotClient;
    private readonly ILogger<DownloadFileQueryHandler> logger;

    public DownloadFileQueryHandler(TelegramBotClient telegramBotClient, ILogger<DownloadFileQueryHandler> logger)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
    }

    public async Task<DownloadFileResult> HandleAsync(DownloadFileQuery query, CancellationToken cancellation)
    {
        var file = await telegramBotClient.GetFileAsync(query.FileId);

        if(file == null)
        {
            logger.LogWarning($"File id: {query.FileId} not found");
            return null;
        }

        using var saveImageStream = new MemoryStream();
        await telegramBotClient.DownloadFileAsync(file.FilePath, saveImageStream);

        return new DownloadFileResult
        {
            File = saveImageStream.ToArray(),
            Path = file.FilePath
        };
    }
}
