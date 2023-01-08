using System.ComponentModel.DataAnnotations.Schema;

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

    [Column(TypeName = "jsonb")]
    public string Response { set; get; }

    public bool IsSuccess { set; get; }

    public BaseRequest(DateTimeOffset requestTime, ApiTypeENUM? apiTypeId, long userId)
	{
		RequestTime = requestTime;
		ApiTypeId = apiTypeId;
        UserId = userId;
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
