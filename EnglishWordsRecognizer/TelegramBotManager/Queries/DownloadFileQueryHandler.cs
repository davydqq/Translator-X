using CQRS.Queries;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace TB.Core.Queries;

public class DownloadFileQueryHandler : IQueryHandler<DownloadFileQuery, byte[]>
{
    private readonly TelegramBotClient telegramBotClient;
    private readonly ILogger logger;

    public DownloadFileQueryHandler(TelegramBotClient telegramBotClient, ILogger logger)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
    }

    public async Task<byte[]> HandleAsync(DownloadFileQuery query, CancellationToken cancellation)
    {
        var file = await telegramBotClient.GetFileAsync(query.FileId);

        if(file == null)
        {
            logger.LogWarning($"File id: {query.FileId} not found");
            return null;
        }

        using var saveImageStream = new MemoryStream();
        await telegramBotClient.DownloadFileAsync(file.FilePath, saveImageStream);

        return saveImageStream.ToArray();
    }
}
