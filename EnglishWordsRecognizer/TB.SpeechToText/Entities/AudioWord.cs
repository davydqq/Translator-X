namespace TB.SpeechToText.Entities;

public class AudioWord
{
    public string Word { set; get; }

    public float Confidence { set; get; }

    public int SpeakerTag { set; get; }

    public TimeSpan StartTime { set; get; }

    public TimeSpan EndTime { set; get; }
}