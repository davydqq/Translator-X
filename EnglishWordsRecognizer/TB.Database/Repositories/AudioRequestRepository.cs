using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class AudioRequestRepository : Repository<AudioRequest, int>
{
    public AudioRequestRepository(TBDatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
