using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TB.Database.Entities;

namespace TB.Database.GenericRepositories
{
    public interface IRepository<T, IdType> where T : BaseEntity<IdType>
    {
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<EntityEntry<T>> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> ents);
        Task AddRangeAsync(List<T> ents);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);

        Task RemoveAsync(T entity);
        Task RemoveIfExistAsync(Expression<Func<T, bool>> predicate);
        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetManyAsync(IEnumerable<IdType> ids);
        Task<List<T>> GetAllNoTrackAsync();
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<bool> GetAnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate);
    }
}
