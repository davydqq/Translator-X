namespace TB.Images.Entities;

public class ImagesInfo
{
    public string TelegramFileId { set; get; }

    public long? Size { set; get; }

    public ImagesInfo(string telegramFileId, long? size)
    {
        TelegramFileId = telegramFileId;
        Size = size;
    }
}
