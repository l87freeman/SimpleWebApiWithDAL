using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using DataAccessLayer.Entities;
using MVCLAbTasks.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MVCLAbTasks.Utils
{
    public static class OrganizationProfile
    {
        public static void CreateProfile()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<GameDTO, Game>()
                    .ForMember(x => x.Comments, opt => opt.Ignore())
                    .ForMember(x => x.Genres, opt => opt.Ignore())
                    .ForMember(x => x.PlatformTypes, opt => opt.Ignore());
                cfg.CreateMap<Game, GameDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<GenreDTO, Genre>();
                cfg.CreateMap<PlatformType, PlatformTypeDTO>();
                cfg.CreateMap<PlatformTypeDTO, PlatformType>();


                cfg.CreateMap<GameView, GameDTO>();
                cfg.CreateMap<GameDTO, GameView>();
                cfg.CreateMap<CommentDTO, CommentView>();
                cfg.CreateMap<CommentView, CommentDTO>();
                cfg.CreateMap<GenreDTO, GenreView>();
                cfg.CreateMap<GenreView, GenreDTO>();
                cfg.CreateMap<PlatformTypeDTO, PlatformTypeView>();
                cfg.CreateMap<PlatformTypeView, PlatformTypeDTO>();
            });
        }
    }
}