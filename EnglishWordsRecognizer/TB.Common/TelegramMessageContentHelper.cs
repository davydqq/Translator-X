using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace TB.Common;

public class TelegramMessageContentHelper
{
    public static bool IsPhotoRoute(Message message) => message.Type == MessageType.Photo || isDocumentPhotoFile(message);

    public static bool isDocumentPhotoFile(Message message)
    {
        var formats = PhotosFormats.GetFormats();
        return message.Document != null && formats.Contains(message.Document.MimeType);
    }


    public static bool IsAudioRoute(Message message) => message.Type == MessageType.Audio || message.Type == MessageType.Voice || isDocumentAudioFile(message);

    public static bool isDocumentAudioFile(Message message)
    {
        var formats = AudiosFormats.GetFormats();
        return message.Document != null && formats.Contains(message.Document.MimeType);
    }

    public static List<ImagesInfo> GetPhotos(Message message)
    {
        switch (message.Type)
        {
            case MessageType.Photo:
                {
                    return message.Photo.Select(x => new ImagesInfo(x.FileId, x.FileSize)).ToList();
                }
            case MessageType.Document:
                {
                    return new List<ImagesInfo> { new ImagesInfo(message.Document.FileId, message.Document.FileSize) };
                }
            default:
                {
                    throw new ArgumentException("Incorrect type");
                }
        }
    }

    public static AudioInfo GetAudio(Message message)
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
