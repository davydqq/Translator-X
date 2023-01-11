using TB.Common.SpeechToText;
using TB.Database.Entities;
using TB.Database.Entities.Requests;

namespace TB.SpeechToText;

public interface ISpeechToTextService
{
    Task<AudioRecognizeResponse> RecognizeAsync(byte[] bytes, LanguageENUM language, string mimeType);

    public ApiTypeENUM ApiType { get; }
}
