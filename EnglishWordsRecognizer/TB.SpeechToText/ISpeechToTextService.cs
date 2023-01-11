using TB.Database.Entities;
using TB.Database.Entities.Requests;
using TB.SpeechToText.Entities;

namespace TB.SpeechToText;

public interface ISpeechToTextService
{
    Task<AudioRecognizeResponse> RecognizeAsync(byte[] bytes, LanguageENUM language, string mimeType);

    public ApiTypeENUM ApiType { get; }
}
