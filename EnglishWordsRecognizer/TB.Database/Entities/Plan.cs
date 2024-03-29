﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TB.Database.Entities.Users;

namespace TB.Database.Entities;

[Table(nameof(Plan), Schema = "billing")]
public class Plan : BaseEntity<PlanENUM>
{
    [Required]
    public string Name { set; get; } = default!;

    public int MaxAnalysisPhotoCountMonth { set; get; }

    public int MaxAudioTranscriptionSecondsMonth { set; get;  }

    public int MaxTranslateCharsMonth { set; get; }

    public double Price { set; get; }

    public bool IsCustomPlan { set; get; }

    public int Priority { set; get; }

    public List<UserPlan> UserPlans { set; get; }
}
