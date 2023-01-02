namespace TB.Audios.Entities;

public class AudioRecognizeResponse
{
    public bool IsSuccess { set; get; }

    public long ProcessedSeconds { set; get; }

    public List<AudioRecognizeResult> Results { set; get; }
}


public class AudioRecognizeResult
{
    public int Tag { set; get; }

    public string LanguageCode { set; get; }

    public TimeSpan EndTime { set; get; }

    public List<AudioTranslate> Alternatives { set; get; }
}

public class AudioTranslate
{
    public string Transcript { set; get; }

    public float Confidence { set; get; }

    public List<AudioWord> Words { set; get; }
}

public class AudioWord
{
    public string Word { set; get; }

    public float Confidence { set; get; }

    public int SpeakerTag { set; get; }

    public TimeSpan StartTime { set; get; }

    public TimeSpan EndTime { set; get; }
}