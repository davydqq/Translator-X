using CQRS.Commands;
using TB.ComputerVision.Entities;

namespace TB.ComputerVision.Command;

public class OCRImageCommand : ICommand<OCR_Result>
{
	public OCRImageCommand(byte[] bytes, long userId)
	{
		Bytes = bytes;
		UserId = userId;
	}

	public byte[] Bytes { get; }

	public long UserId { get; }
}
