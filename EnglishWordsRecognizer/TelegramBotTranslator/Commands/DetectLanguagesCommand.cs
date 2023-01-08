using CQRS.Commands;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class DetectLanguagesCommand : ICommand<List<DetectLanguageResponse>>
{
	public DetectLanguagesCommand(string textToDetect, long userId)
	{
		TextToDetect = textToDetect;
		UserId = userId;
	}

    public string TextToDetect { get; }

	public long UserId { get; }
}
