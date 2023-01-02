using TB.Audios.Commands;
using TB.Audios.Entities;
using TB.Common;
using TB.Routing;
using TB.Routing.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Routing.Routes.CoreRoutes;

public class ParseAudiosRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Audio || message.Type == MessageType.Voice || isAudioFile(message);
    }

    private bool isAudioFile(Message message)
    {
        var formats = AudiosFormats.GetFormats();
        return message.Document != null && formats.Contains(message.Document.MimeType);
    }

    public BaseRouteResult GetCommand(Update update)
    {
        var message = update.Message;

        var userId = message.From.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var file = GetAudio(message);

        var command = new HandleAudiosCommand(chatId, userId, messageId, file);

        return new BaseRouteResult(command);
    }

    private AudioInfo GetAudio(Message message)
    {
        switch (message.Type)
        {
            case MessageType.Voice:
                {
                    return new AudioInfo()
                    {
                        FileId = message.Voice.FileId,
                        Duration = message.Voice.Duration,
                        MimeType = message.Voice.MimeType
                    };
                }
            case MessageType.Audio:
                {
                    return new AudioInfo()
                    {
                        FileId = message.Audio.FileId,
                        Duration = message.Audio.Duration,
                        MimeType = message.Audio.MimeType
                    };
                }
            case MessageType.Document:
                {
                    return new AudioInfo()
                    {
                        FileId = message.Document.FileId,
                        MimeType = message.Document.MimeType
                    };
                }
            default:
                {
                    throw new ArgumentException("Incorrect type");
                }
        }
    }
}
