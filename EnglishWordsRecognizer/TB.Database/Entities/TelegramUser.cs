using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TB.Database.Entities;

public class TelegramUser: BaseEntity<int>
{
    [NotMapped]
    public override int Id { get => throw new Exception("Field can not be used!"); set => throw new Exception("Field can not be used!"); }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long TelegramUserId { get; set; }

    public bool IsBot { set; get; }

    public string FirstName { get; set; } = default!;

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? LanguageCode { get; set; }
}
