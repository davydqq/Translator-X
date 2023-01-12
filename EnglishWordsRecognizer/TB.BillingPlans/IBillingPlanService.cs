using TB.Database.Entities.Requests;
using TB.Database.Entities;

namespace TB.BillingPlans;

public interface IBillingPlanService
{
    Task<(List<ImageRequest> request, UserPlan plan)> GetPaidPlanImageRequestsAsync(long userId);
    Task<bool> IsCanProcessImageAsync(long userId);


    Task<(List<TextRequest> request, UserPlan plan)> GetPaidPlanTextRequestAsync(long userId);
    Task<bool> IsCanProcessTextAsync(long userId);

    Task<(List<AudioRequest> request, UserPlan plan)> GetPaidPlanAudioRequestAsync(long userId);
    Task<bool> IsCanProcessAudioAsync(long userId);
}
