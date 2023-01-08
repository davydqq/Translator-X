using CQRS.Commands;
using TB.ComputerVision.Entities;

namespace TB.ComputerVision.Command;

public class AnalyzeImageCommand : ICommand<VisionResult>
{
	public AnalyzeImageCommand(byte[] bytes, long userId)
	{
		Bytes = bytes;
		UserId = userId;
	}

	public byte[] Bytes { get; }
	public long UserId { get; }
}
