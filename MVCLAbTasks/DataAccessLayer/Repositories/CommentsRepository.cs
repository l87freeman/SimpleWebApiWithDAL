using DataAccessLayer.EFContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AbstractRepositories;

namespace DataAccessLayer.Repositories
{
    public class CommentsRepository : ManipulationRepository<Comment>
    {
        public CommentsRepository(StoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
