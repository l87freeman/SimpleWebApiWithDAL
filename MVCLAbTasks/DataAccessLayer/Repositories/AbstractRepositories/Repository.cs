using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.EFContext;
using DataAccessLayer.Entities.AbstractEntities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories.AbstractRepositories
{
    public abstract class Repository<T> : IRepository<T> where T:Entity
    {
        private readonly StoreDbContext _dbContext;

        //public DbSet<T> RepositoryDbSet => _dbContext.Set<T>();
        public StoreDbContext Context => _dbContext;

        protected Repository(StoreDbContext context)
        {
            _dbContext = context;
        }

        public virtual T Get<TKey>(TKey id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
    }
}
