using CQRS.Commands;
using TB.Common;
using TB.Images.Entities;

namespace TB.Images.Commands;

public class HandleImagesCommand : BaseTelegramMessageCommand, ICommand
{
	public HandleImagesCommand(long chatId, long userId, int messageId, string caption, List<ImagesInfo> files)
        : base(chatId, userId, messageId)
    {
		Caption = caption;
		Files = files;
	}

	public string Caption { get; }

	public List<ImagesInfo> Files { get; }
}
