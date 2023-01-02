using CQRS.Queries;
using TB.Core.Entities;

namespace TB.Core.Queries;

public class DownloadFileQuery : IQuery<DownloadFileResult>
{
	public DownloadFileQuery(string fileId)
	{
		FileId = fileId;
	}

	public string FileId { get; }
}
