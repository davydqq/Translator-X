namespace TB.SpeechToText.Entities;

public class AudioRecognizeResult
{
    public int Tag { set; get; }

    public string LanguageCode { set; get; }

    public TimeSpan EndTime { set; get; }

    public List<AudioTranslate> Alternatives { set; get; }
}
