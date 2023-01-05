using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities;

[Table(nameof(Language), Schema = "app")]
public class Language : BaseEntity<LanguageENUM>
{
    [Required]
    public string Name { set; get; } = default!;

    [Required]
    public string Code { set; get; } = default!;

    public string? DisplayCode { set; get; }

    public bool IsSupportInteface { set; get; }

    public bool IsSupportAudioTranscription { set; get; }

    public bool IsSupportTargetLanguage { set; get; }

    public bool IsSupportNativeLanguage { set; get; }

    public List<UserSettings> UserSettingsNativeLangs { set; get; }

    public List<UserSettings> UserSettingsTargetLangs { set; get; }

    public List<UserSettings> UserSettingsInterfaceLangs { set; get; }

    public List<UserSettings> UserSettingsAudioLangs { set; get; }

    public List<Translation> Translations { set; get; }

    public string GetCode()
    {
        return DisplayCode ?? Code;
    }
}
