using CQRS.Commands;
using TB.Database.Entities;
using TB.SpeechToText.Entities;

namespace TB.SpeechToText.Commands;

public class AudioToTextCommand : ICommand<AudioRecognizeResponse>
{
	public AudioToTextCommand(byte[] bytes, LanguageENUM language, string mimeType, long userId)
	{
		Bytes = bytes;
		Language = language;
		MimeType = mimeType;
		UserId = userId;
	}

	public byte[] Bytes { get; }
	public LanguageENUM Language { get; }
	public string MimeType { get; }
	public long UserId { get; }
}
