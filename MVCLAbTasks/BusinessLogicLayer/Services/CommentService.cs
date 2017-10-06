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
    public class CommentService:Service, ICommentService
    {
        public CommentService(IUnitOfWork uow) : base(uow)
        {
        }

        public void Create(CommentDTO entity)
        {
            var entry = AutoMapper.Mapper.Map<Comment>(entity);
            try
            {
                Db.CommentsRepository.Create(entry);
                Db.Save();
            }
            catch (Exception e)
            {
                throw new ServiceException("Create comment exception", e);
            }
        }

        public ICollection<CommentDTO> GetGameComments(GameDTO game)
        {
            try
            {
                //TODO make generic method GetAll(Predicate<T>)
                var comments = Db.GamesRepository.GetAll().First(g => g.Key == game.Key).Comments;
                return AutoMapper.Mapper.Map<ICollection<CommentDTO>>(comments);
            }
            catch (Exception e)
            {
                throw new ServiceException("Get comments by game exception", e);
            }
        }
    }
}
