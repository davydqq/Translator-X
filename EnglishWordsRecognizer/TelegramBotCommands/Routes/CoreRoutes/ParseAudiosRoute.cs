using TB.Audios.Commands;
using TB.Audios.Entities;
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
        return message.Type == MessageType.Audio || message.Type == MessageType.Voice;
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
            default:
                {
                    throw new ArgumentException("Incorrect type");
                }
        }
    }
}
