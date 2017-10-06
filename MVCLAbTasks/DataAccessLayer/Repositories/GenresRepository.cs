using DataAccessLayer.EFContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AbstractRepositories;

namespace DataAccessLayer.Repositories
{
    public class GenresRepository: Repository<Genre>
    {
        public GenresRepository(StoreDbContext dbContext):base(dbContext)
        {
        }
    }
}
