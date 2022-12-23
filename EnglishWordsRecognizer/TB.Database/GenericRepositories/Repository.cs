using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TB.Database.Entities;

namespace TB.Database.GenericRepositories
{
    public class Repository<T, IdType> : ModifyRepository<T>, IRepository<T, IdType> where T : BaseEntity<IdType> where IdType : struct
    {
        public readonly TBDatabaseContext context;

        protected DbSet<T> entities;

        public Repository(TBDatabaseContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => entities.FirstOrDefaultAsync(predicate);

        // GET
        public virtual Task<List<T>> GetAllAsync()
        {
            return entities.ToListAsync();
        }

        public virtual Task<List<T>> GetAllNoTrackAsync()
        {
            return entities.AsNoTracking().ToListAsync();
        }

        public Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate).ToListAsync();
        }

        public Task<List<T>> GetManyAsync(IEnumerable<IdType> ids)
        {
            return entities.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public Task<int> GetCountAsync(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate).CountAsync();
        }

        public Task<bool> GetAnyAsync(Expression<Func<T, bool>> predicate)
        {
            return entities.AnyAsync(predicate);
        }
    }
}
