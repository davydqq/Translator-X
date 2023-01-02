namespace TB.Common;

public static class AudiosFormats
{
    private static string[] Formats = new string[] { Flac, MP3, OGG, WAV, X_WAV };

    public const string Flac = "audio/flac";

    public const string MP3 = "audio/mpeg";

    public const string OGG = "audio/ogg";

    public const string WAV = "audio/wav";

    public const string X_WAV = "audio/x-wav";

    public static string[] GetFormats()
    {
        return Formats;
    }
}