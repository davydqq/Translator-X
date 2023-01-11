using TB.Database.Entities;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class TextRequestRepository : Repository<TextRequest, int>
{
    public TextRequestRepository(TBDatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
