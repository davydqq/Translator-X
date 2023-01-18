using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TB.Database.Entities.Requests;

namespace TB.Database.Entities.Users;

[Table(nameof(TelegramUser), Schema = "app")]
public class TelegramUser : BaseEntity<int>
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


    public UserSettings UserSettings { set; get; }

    public List<BaseRequest> BaseRequests { set; get; }

    public List<UserPlan> UserPlans { set; get; }

    public List<UserRole> UserRoles { set; get; }
}
