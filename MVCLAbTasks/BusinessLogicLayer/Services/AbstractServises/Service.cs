using System;
using DataAccessLayer.UnitsOfWork.Interfaces;

namespace BusinessLogicLayer.Services.AbstractServises
{
    public abstract class Service:IDisposable
    {
        private readonly IUnitOfWork _database;

        protected IUnitOfWork Db => _database;

        protected Service(IUnitOfWork uow)
        {
            _database = uow;
        }

        public void Dispose()
        {
            _database?.Dispose();
        }
    }
}
