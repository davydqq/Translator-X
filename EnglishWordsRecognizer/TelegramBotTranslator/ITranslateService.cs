using TB.Database.Entities;
using TB.Database.Entities.Requests;
using TB.Translator.Entities;

namespace TB.Translator;

public interface ITranslateService
{
    Task<List<DetectLanguageResponse>> DetectLanguagesAsync(string[] textToDetect);
    Task<List<TranslateResponse>> TranslateTextsAsync(string[] textToTranslate, Language language);

    ApiTypeENUM apiTypeENUM { get; }

    double Costs { get; }
}
