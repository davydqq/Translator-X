using System.ComponentModel.DataAnnotations.Schema;
using TB.Common;
using TB.Database.Entities.Users;

namespace TB.Database.Entities.Requests;

[Table(nameof(BaseRequest), Schema = "requests")]
public class BaseRequest : BaseEntity<int>
{
    public DateTimeOffset RequestTime { set; get; }

	public double RequestCost { set; get; }

    public ApiTypeENUM? ApiTypeId { set; get; }
    public ApiType ApiType { set; get; }


    public long UserId { set; get; }
    public TelegramUser User { set; get; }


    public int UserPlanId { set; get; }
    public UserPlan UserPlan { set; get; }


    [Column(TypeName = "jsonb")]
    public string Response { set; get; }

    public bool IsSuccess { set; get; }

    public BaseRequest(ApiTypeENUM? apiTypeId, long userId, int userPlanId)
	{
		RequestTime = TimeProvider.Get();
		ApiTypeId = apiTypeId;
        UserId = userId;
        UserPlanId = userPlanId;
    }

    public virtual BaseRequest InitResponse(string response, bool isSuccess)
    {
        Response = response;
        IsSuccess = isSuccess;  

        return this;
    }

    protected void InitCost(double cost)
    {
        RequestCost = Math.Round(cost, 7);
    }
}
