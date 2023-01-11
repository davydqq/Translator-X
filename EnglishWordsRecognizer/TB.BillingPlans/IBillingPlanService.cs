using TB.Database.Entities.Requests;
using TB.Database.Entities;

namespace TB.BillingPlans;

public interface IBillingPlanService
{
    Task<(List<ImageRequest> request, PlanENUM plan)> GetPlanImageRequestsAsync(long userId);
    Task<bool> IsCanProcessImageAsync(long userId);


    Task<(List<TextRequest> request, PlanENUM plan)> GetPlanTextRequestAsync(long userId);
    Task<bool> IsCanProcessTextAsync(long userId);

    Task<(List<AudioRequest> request, PlanENUM plan)> GetPlanAudioRequestAsync(long userId);
    Task<bool> IsCanProcessAudioAsync(long userId);
}
