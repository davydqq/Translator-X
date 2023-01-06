using CQRS.Commands;

namespace TB.Meaning.Commands;

public class GetSynonymsCommand : ICommand<IEnumerable<string>>
{
    public string Text { set; get; }

	public GetSynonymsCommand(string text)
	{
		Text = text;
	}
}
