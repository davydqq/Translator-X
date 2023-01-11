using System.ComponentModel.DataAnnotations.Schema;
using TB.Database.Entities.Requests;

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

    public List<BaseRequest> Requests { set; get; }

    public UserPlan InitBase(long userId)
    {
        StartDate = DateTimeOffset.UtcNow;
        ExpireDate = StartDate.AddDays(30);
        PlanId = PlanENUM.Standart;
        UserId = userId;

        return this;
    }
}
