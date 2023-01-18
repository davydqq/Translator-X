using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Users;

[Table("UserRoles", Schema = "app")]
public class UserRole: BaseEntity<int>
{
    [NotMapped]
    public override int Id { get => throw new Exception("Field can not be used!"); set => throw new Exception("Field can not be used!"); }

    public RoleENUM RoleId { set; get; }
    public Role Role { set; get; }

    public long TelegramUserId { set; get; }
    public TelegramUser TelegramUser { set; get; }
}
