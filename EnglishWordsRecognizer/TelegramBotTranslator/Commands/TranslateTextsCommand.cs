using CQRS.Commands;
using TB.Database.Entities;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class TranslateTextsCommand : ICommand<List<TranslateResponse>>
{
    public List<string> TextsToTranslate { get; }

    public Language LanguageToTranslate { get; }

    public long UserId { get; }

    public TranslateTextsCommand(List<string> textsToTranslate, Language languageToTranslate, long userId)
    {
        TextsToTranslate = textsToTranslate;
        LanguageToTranslate = languageToTranslate;
        UserId = userId;
    }
}
