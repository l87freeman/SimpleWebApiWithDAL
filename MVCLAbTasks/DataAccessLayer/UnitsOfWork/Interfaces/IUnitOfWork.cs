using System;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.UnitsOfWork.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IManipulationRepository<Game> GamesRepository { get; }
        IManipulationRepository<Comment> CommentsRepository { get; }
        IRepository<Genre> GenresRepository { get; }
        IRepository<PlatformType> PlatformTypesRepository { get; }

        void Save();
    }
}
