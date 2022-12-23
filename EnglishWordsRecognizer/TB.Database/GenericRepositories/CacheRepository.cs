using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TB.Database.Entities;

namespace TB.Database.GenericRepositories;

public abstract class CacheRepository<T, IdType, TKey> : ModifyRepository<T>, ICacheRepository<T, IdType, TKey> 
            where T : BaseEntity<IdType> 
            where IdType : struct
{

    public readonly TBDatabaseContext context;

    protected DbSet<T> entities;

    protected List<T> cachedEnts;

    public Dictionary<TKey, T> cachedDictionary;

    public CacheRepository(TBDatabaseContext context) : base(context)
    {
        this.context = context;
        entities = context.Set<T>();
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        await InitAsync();
        return cachedEnts.FirstOrDefault(predicate.Compile());
    }

    public async Task<List<T>> GetAllAsync()
    {
        await InitAsync();
        return cachedEnts;
    }

    public Task<List<T>> GetAllNoTrackAsync()
    {
        return GetAllAsync();
    }

    public async Task<bool> GetAnyAsync(Expression<Func<T, bool>> predicate)
    {
        await InitAsync();
        return cachedEnts.Any(predicate.Compile());
    }

    public async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate)
    {
        var ents = await GetWhereAsync(predicate);
        return ents.Count;
    }

    public async Task<List<T>> GetManyAsync(IEnumerable<IdType> ids)
    {
        await InitAsync();
        return cachedEnts.Where(x => ids.Contains(x.Id)).ToList();
    }

    public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
    {
        await InitAsync();
        return cachedEnts.Where(predicate.Compile()).ToList();
    }

    protected async Task InitAsync()
    {
        if(cachedEnts == null)
        {
            cachedEnts = await entities.ToListAsync();
        }
    }

    public abstract Task CreateDictionaryByKey();

    public abstract T GetByKeyOrDefault(TKey key);
}
