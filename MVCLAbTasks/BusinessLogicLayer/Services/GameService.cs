using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Services.AbstractServises;
using BusinessLogicLayer.Services.Exceptions;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitsOfWork.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class GameService : Service, IGameService
    {
        public GameService(IUnitOfWork ouw) : base(ouw)
        {
        }

        public void Create(GameDTO entity)
        {
            var entry = AutoMapper.Mapper.Map<Game>(entity);

            entry.Genres = entity.Genres.Select(gentre => Db.GenresRepository.Get(gentre.Name)).ToList();
            entry.PlatformTypes = entity.PlatformTypes.Select(plType => Db.PlatformTypesRepository.Get(plType.Type))
                .ToList();
            entry.Comments = entity.Comments.Select(comment => Db.CommentsRepository.Get(comment.CommentId)).ToList();
            try
            {
                Db.GamesRepository.Create(entry);
                Db.Save();
            }
            catch (Exception e)
            {
                throw new ServiceException("Create game exception", e);
            }
        }

        public void Delete(GameDTO entity)
        {
            var entry = AutoMapper.Mapper.Map<Game>(entity);
            try
            {
                Db.GamesRepository.Delete(entry, entry.Key);
                Db.Save();
            }
            catch (Exception e)
            {
                throw new ServiceException("Delete game exception", e);
            }
        }

        public GameDTO Get<TKey>(TKey id)
        {
            try
            {
                var entry = Db.GamesRepository.Get(id);
                if (entry == null)
                    throw new ArgumentException("Wrong id passed for search");
                return AutoMapper.Mapper.Map<GameDTO>(entry);
            }
            catch (Exception e)
            {
                throw new ServiceException("Get game exception", e);
            }
        }

        public ICollection<GameDTO> GetAll()
        {
            try
            {
                var entry = Db.GamesRepository.GetAll();
                var list = AutoMapper.Mapper.Map<List<GameDTO>>(entry);
                return list;
            }
            catch (Exception e)
            {
                throw new ServiceException("Get all games exception", e);
            }
        }

        public void Update(GameDTO entity)
        {
            var entry = AutoMapper.Mapper.Map<Game>(entity);
            try
            {
                Db.GamesRepository.Update(entry);
                Db.Save();
            }
            catch (Exception e)
            {
                throw new ServiceException("Update game exception", e);
            }
        }

        public ICollection<GameDTO> GetGamesByGanre(GenreDTO genre)
        {
            try
            {
                //TODO make generic method GetAll(Predicate<T>)
               var games = Db.GenresRepository.GetAll().First(g => g.Name == genre.Name).Games;
               return AutoMapper.Mapper.Map<ICollection<GameDTO>>(games);
            }
            catch (Exception e)
            {
                throw new ServiceException("Get game by genre exception", e);
            }
        }

        public ICollection<GameDTO> GetGamesByPlatfornType(PlatformTypeDTO platformType)
        {
            try
            {
                //TODO make generic method GetAll(Predicate<T>)
                var games = Db.PlatformTypesRepository.GetAll().First(p => p.Type == platformType.Type).Games;
                return AutoMapper.Mapper.Map<ICollection<GameDTO>>(games);
            }
            catch (Exception e)
            {
                throw new ServiceException("Get game by platform type exception", e);
            }
        }
    }
}
