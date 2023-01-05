using System.ComponentModel.DataAnnotations;

namespace TB.Database.Entities;

public class Plan : BaseEntity<PlanENUM>
{
    [Required]
    public string Name { set; get; } = default!;

    public int MaxAnalysisPhotoCountMonth { set; get; }

    public int MaxAudioTranscriptionSecondsMonth { set; get;  }

    public int MaxTranslateCharsMonth { set; get; }

    public double Price { set; get; }

    public bool IsCustomPlan { set; get; }

    public List<TelegramUser> TelegramUsers { set; get; }
}
