using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Users;

[Table("Roles", Schema = "app")]
public class Role : BaseEntity<RoleENUM>
{
    public string Name { set; get; }

    public List<UserRole> UserRoles { set; get; }
}
