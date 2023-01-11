namespace TB.BillingPlans;

public interface IBillingPlanService
{
    Task<bool> IsCanProcessImageAsync(long userId);

    Task<bool> IsCanProcessTextAsync(long userId);
    Task<bool> IsCanProcessAudioAsync(long userId);
}
