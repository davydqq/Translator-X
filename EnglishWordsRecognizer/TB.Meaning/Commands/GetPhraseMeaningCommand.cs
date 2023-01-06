using CQRS.Commands;
using TB.Meaning.Entities;

namespace TB.Meaning.Commands;

public class GetPhraseMeaningCommand : ICommand<MeaningResult>
{
    public string Text { set; get; }

	public GetPhraseMeaningCommand(string text)
	{
		Text = text;
	}
}
