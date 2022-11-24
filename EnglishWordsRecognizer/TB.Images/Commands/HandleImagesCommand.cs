using CQRS.Commands;
using TB.Images.Entities;

namespace TB.Images.Commands;

public class HandleImagesCommand : ICommand
{
	public HandleImagesCommand(long chatId, long userId, int messageId, List<ImagesInfo> files)
	{
		ChatId = chatId;
		UserId = userId;
		MessageId = messageId;
        Files = files;
	}

	public long ChatId { get; }
	public long UserId { get; }
	public int MessageId { get; }
	public List<ImagesInfo> Files { get; }
}
