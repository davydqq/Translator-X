using TB.Audios.Entities;
using TB.Database.Entities;

namespace TB.Audios;

public interface ISpeechToTextService
{
    Task<AudioRecognizeResponse> RecognizeAsync(byte[] bytes, LanguageENUM language, string mimeType);
}
