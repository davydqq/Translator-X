using CQRS.Commands;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class TranslateTextsCommand : ICommand<List<TranslateResponse>>
{
    public List<string> TextsToTranslate { set; get; }

    public List<string> LanguagesToTranslate { set; get; }
}
