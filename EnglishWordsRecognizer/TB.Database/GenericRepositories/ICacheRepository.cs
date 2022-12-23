using TB.Database.Entities;

namespace TB.Database.GenericRepositories;

public interface ICacheRepository<T, IdType, TKey> : IRepository<T, IdType> where T : BaseEntity<IdType>
{
    T GetByKeyOrDefault(TKey key);
}
