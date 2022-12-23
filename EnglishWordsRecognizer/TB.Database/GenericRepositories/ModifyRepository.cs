using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
namespace TB.Database.GenericRepositories;

public class ModifyRepository<T> where T : class
{
    public readonly TBDatabaseContext context;

    protected DbSet<T> entities;

    public ModifyRepository(TBDatabaseContext context)
    {
        this.context = context;
        entities = context.Set<T>();
    }

    // UPDATE
    public async Task UpdateRangeAsync(IEnumerable<T> ents)
    {
        entities.UpdateRange(ents);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        entities.Update(entity);
        await context.SaveChangesAsync();
    }

    // ADD
    public async Task AddRangeAsync(IEnumerable<T> ents)
    {
        await entities.AddRangeAsync(ents);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<T> ents)
    {
        await entities.AddRangeAsync(ents);
        await context.SaveChangesAsync();
    }

    public async Task<EntityEntry<T>> AddAsync(T entity)
    {
        var ent = await entities.AddAsync(entity);
        await context.SaveChangesAsync();
        return ent;
    }

    // REMOVE
    public async Task RemoveAsync(T entity)
    {
        entities.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task RemoveIfExistAsync(Expression<Func<T, bool>> predicate)
    {
        var ent = await entities.FirstOrDefaultAsync(predicate);
        if (ent != null)
        {
            entities.Remove(ent);
            await context.SaveChangesAsync();
        }
    }

    public async Task RemoveRangeAsync(IEnumerable<T> ents)
    {
        entities.RemoveRange(ents);
        await context.SaveChangesAsync();
    }
}
