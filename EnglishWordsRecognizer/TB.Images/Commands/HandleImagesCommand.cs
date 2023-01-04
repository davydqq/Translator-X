using CQRS.Commands;
using TB.Common;
using Telegram.Bot.Types;

namespace TB.Images.Commands;

public class HandleImagesCommand : BaseTelegramMessageCommand, ICommand<bool>
{
	public HandleImagesCommand(long chatId, long userId, int messageId, string caption, List<ImagesInfo> files, Update update)
        : base(chatId, userId, messageId, update)
    {
		Caption = caption;
		Files = files;
	}

	public string Caption { get; }

	public List<ImagesInfo> Files { get; }
}
