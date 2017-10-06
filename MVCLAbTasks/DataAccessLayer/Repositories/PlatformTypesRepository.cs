using DataAccessLayer.EFContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AbstractRepositories;

namespace DataAccessLayer.Repositories
{
    public class PlatformTypesRepository:Repository<PlatformType>
    {
      public PlatformTypesRepository(StoreDbContext dbContext):base(dbContext)
        { }
    }
}
