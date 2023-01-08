using CQRS.Commands;

namespace TB.Meaning.Commands;

public class GetSynonymsCommand : ICommand<IEnumerable<string>>
{
    public string Text { set; get; }

	public long UserId { get; }

	public GetSynonymsCommand(string text, long userId)
	{
		Text = text;
		UserId = userId;
	}
}
