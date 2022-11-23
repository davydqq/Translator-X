using CQRS.Queries;

namespace TB.Core.Queries;

public class DownloadFileQuery : IQuery<byte[]>
{
	public DownloadFileQuery(string fileId)
	{
		FileId = fileId;
	}

	public string FileId { get; }
}
