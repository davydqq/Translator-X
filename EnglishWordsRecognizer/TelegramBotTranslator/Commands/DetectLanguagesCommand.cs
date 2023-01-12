using CQRS.Commands;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class DetectLanguagesCommand : ICommand<List<DetectLanguageResponse>>
{
	public DetectLanguagesCommand(string textToDetect, long userId)
	{
		TextToDetect = ProcessText(textToDetect);
		UserId = userId;
	}

	public string ProcessText(string textToDetect)
	{
		if(textToDetect.Length > 50)
		{
			return textToDetect.Substring(0, 50);

        }

		return textToDetect;
    }

    public string TextToDetect { get; }

	public long UserId { get; }
}
