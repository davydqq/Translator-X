namespace TB.SpeechToText.Entities;

public class AudioRecognizeResponse
{
    public bool IsSuccess { set; get; }

    public long ProcessedSeconds { set; get; }

    public List<AudioRecognizeResult> Results { set; get; }
}
