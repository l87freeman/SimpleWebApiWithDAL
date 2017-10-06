using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDataContext:IDisposable
    {
        void Create<T>(T entry) where T : class;
        void Delete<T>(T entry) where T : class;
        void Update<T>(T entry) where T : class;
        T Get<T>(int id) where T : class;
        ICollection<T> GetAll<T>() where T : class;
    }
}
