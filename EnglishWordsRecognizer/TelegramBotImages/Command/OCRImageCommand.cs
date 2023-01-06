using CQRS.Commands;
using TB.ComputerVision.Entities;

namespace TB.ComputerVision.Command;

public class OCRImageCommand : ICommand<OCR_Result>
{
	public OCRImageCommand(byte[] bytes)
	{
		Bytes = bytes;
	}

	public byte[] Bytes { get; }
}
