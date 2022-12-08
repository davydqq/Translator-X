using TB.Audios.Entities;

namespace TB.Audios;

public interface ISpeechToTextService
{
    Task<AudioRecognizeResponse> RecognizeAsync(byte[] bytes);
}
