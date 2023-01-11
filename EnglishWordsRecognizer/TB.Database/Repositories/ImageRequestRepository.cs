using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class ImageRequestRepository : Repository<ImageRequest, int>
{
    public ImageRequestRepository(TBDatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
