using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DataAccessLayer.EFContext;
using DataAccessLayer.Entities.AbstractEntities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories.AbstractRepositories
{
    public abstract class ManipulationRepository<T> : Repository<T>, IManipulationRepository<T> where T: Entity
    {
        protected ManipulationRepository(StoreDbContext context) : base(context)
        {
        }

        public virtual void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete<TKey>(T entity, TKey key)
        {
            var entityProxy = Context.Set<T>().Find(key);
            if (entityProxy != null)
            {
                var entry = Context.Entry(entityProxy);
                entry.State = EntityState.Deleted;
                Context.SaveChanges();
            }
            
        }

        public virtual void Update(T entity)
        {
            CheckAttach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        private void CheckAttach(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Context.Set<T>().Attach(entry.Entity);
        }
    }
}
