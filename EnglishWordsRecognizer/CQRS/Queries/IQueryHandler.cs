namespace CQRS.Queries;

public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : class, IQuery<TQueryResult>
{
    Task<TQueryResult> HandleAsync(TQuery query, CancellationToken cancellation);
}
