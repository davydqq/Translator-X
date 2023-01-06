namespace TB.SpeechToText.Entities;

public class AudioTranslate
{
    public string Transcript { set; get; }

    public float Confidence { set; get; }

    public List<AudioWord> Words { set; get; }
}
