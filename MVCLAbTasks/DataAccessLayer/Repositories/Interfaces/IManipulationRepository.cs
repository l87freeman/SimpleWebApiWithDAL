using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IManipulationRepository<T>: IRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete<TKey>(T entity, TKey key);
    }
}
