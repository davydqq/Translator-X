using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities;

[Table("Payments", Schema = "app")]
public class Payment : BaseEntity<int>
{
    public DateTimeOffset PaymentDate { set; get; }

    public PlanENUM PlanId { set; get; }
    public Plan Plan { set; get; }
}
