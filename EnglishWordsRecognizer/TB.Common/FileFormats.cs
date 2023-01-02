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

public static class PhotosFormats
{
    private static string[] Formats = new string[] { JPEG, PNG, PNG1 };

    public const string JPEG = "image/jpeg";

    public const string PNG = "image/png";

    public const string PNG1 = "image/x-png";

    public static string[] GetFormats()
    {
        return Formats;
    }
}

public static class  PhotosExtension
{
    private static string[] Formats = new string[] { JPEG, JPEG_1, PNG };

    public const string JPEG = ".jpeg";

    public const string JPEG_1 = ".jpg";

    public const string PNG = ".png";

    public static string[] GetFormats()
    {
        return Formats;
    }
}