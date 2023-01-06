using CQRS.Commands;
using TB.ComputerVision.Entities;

namespace TB.ComputerVision.Command;

public class AnalyzeImageCommand : ICommand<VisionResult>
{
	public AnalyzeImageCommand(byte[] bytes)
	{
		Bytes = bytes;
	}

	public byte[] Bytes { get; }
}
