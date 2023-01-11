using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities;

[Table("UserPlans", Schema = "app")]
public class UserPlan: BaseEntity<int>
{
    public DateTimeOffset StartDate { set; get; }

    public DateTimeOffset ExpireDate { set; get; }

    public DateTimeOffset? PaymentDate { set; get; }

    public PlanENUM PlanId { set; get; }
    public Plan Plan { set; get; }

    public long UserId { set; get; }
    public TelegramUser User { set; get; }
}
