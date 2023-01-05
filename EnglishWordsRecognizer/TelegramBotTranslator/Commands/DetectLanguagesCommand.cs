using CQRS.Commands;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class DetectLanguagesCommand : ICommand<List<DetectLanguageResponse>>
{
    public string TextToDetect { set; get; }
}
