using DataAccessLayer.EFContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWork.Interfaces;
using DataAccessLayer.Utility;

namespace DataAccessLayer.UnitsOfWork
{
    public class EfUnitOfWork: IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;
        private IManipulationRepository<Game> _gamesRepository;
        private IManipulationRepository<Comment> _commentsRepository;
        private IRepository<Genre> _genresRepository;
        private IRepository<PlatformType> _platformTypesRepository;

        public EfUnitOfWork()
        {
            _dbContext = new StoreDbContext(ConfigReader.EFConnection);
        }

        public IManipulationRepository<Game> GamesRepository => 
            _gamesRepository ?? (_gamesRepository = new GamesRepository(_dbContext));

        public IManipulationRepository<Comment> CommentsRepository =>
            _commentsRepository ?? (_commentsRepository = new CommentsRepository(_dbContext));

        public IRepository<Genre> GenresRepository =>
            _genresRepository ?? (_genresRepository = new GenresRepository(_dbContext));

        public IRepository<PlatformType> PlatformTypesRepository =>
            _platformTypesRepository ?? (_platformTypesRepository = new PlatformTypesRepository(_dbContext));

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

    }
}
