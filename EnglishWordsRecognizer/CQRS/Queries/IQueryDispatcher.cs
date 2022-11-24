namespace CQRS.Queries;

public interface IQueryDispatcher
{
    Task<TQueryResult> DispatchAsync<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellation = default);
}
