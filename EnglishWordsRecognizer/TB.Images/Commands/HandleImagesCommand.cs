using CQRS.Commands;
using TB.Images.Entities;

namespace TB.Images.Commands;

public class HandleImagesCommand : ICommand
{
	public HandleImagesCommand(long chatId, long userId, int messageId, string caption, List<ImagesInfo> files)
	{
		ChatId = chatId;
		UserId = userId;
		MessageId = messageId;
		Caption = caption;
		Files = files;
	}

	public long ChatId { get; }

	public long UserId { get; }

	public int MessageId { get; }

	public string Caption { get; }

	public List<ImagesInfo> Files { get; }
}
