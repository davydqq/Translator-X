using CQRS.Commands;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class TranslateTextsCommand : ICommand<List<TranslateResponse>>
{
    public List<string> TextsToTranslate { get; }

    public List<string> LanguagesToTranslate { get; }

    public long UserId { get; }

    public TranslateTextsCommand(List<string> textsToTranslate, List<string> languagesToTranslate, long userId)
    {
        TextsToTranslate = textsToTranslate;
        LanguagesToTranslate = languagesToTranslate;
        UserId = userId;
    }
}
