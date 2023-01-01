using System.ComponentModel.DataAnnotations;

namespace TB.Database.Entities;

public class Language : BaseEntity<LanguageENUM>
{
    [Required]
    public string Name { set; get; } = default!;

    [Required]
    public string Code { set; get; } = default!;

    public string? DisplayName { set; get; }

    public bool IsSupportInteface { set; get; }

    public bool IsSupportAudioTranscription { set; get; }

    public bool IsSupportTargetLanguage { set; get; }

    public bool IsSupportNativeLanguage { set; get; }

    public List<UserSettings> UserSettingsNativeLangs { set; get; }

    public List<UserSettings> UserSettingsTargetLangs { set; get; }

    public List<UserSettings> UserSettingsInterfaceLangs { set; get; }

    public List<UserSettings> UserSettingsAudioLangs { set; get; }

    public List<Translation> Translations { set; get; }

    public string GetName()
    {
        return DisplayName ?? Name;
    }
}
