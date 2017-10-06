using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Services.Interfaces;
using MVCLAbTasks.Models.Entities;

namespace MVCLAbTasks.Models.Infrastructure
{
    public class GamesProxy
    {
        private readonly IGameService _gameService;
        private readonly ICommentService _commentService;

        public GamesProxy(IGameService gameService, ICommentService commentService)
        {
            _gameService = gameService;
            _commentService = commentService;
        }

        public ICollection<GameView> GetAllGames()
        {
            var games = _gameService.GetAll();
            return Mapper.Map<ICollection<GameView>>(games);
        }

        public GameView Get(string id)
        {
            var game = _gameService.Get(id);
            return Mapper.Map<GameView>(game);
        }

        public void CreateGame(GameView game)
        {
            var mappedGame = Mapper.Map<GameDTO>(game);
            _gameService.Create(mappedGame);
        }

        public void UpdateGame(GameView game)
        {
            var mappedGame = Mapper.Map<GameDTO>(game);
            _gameService.Update(mappedGame);
        }

        public void RemoveGame(GameView game)
        {
            var entry = _gameService.Get(game.Key);
            _gameService.Delete(entry);
        }

        public FileStream GetGameStream(string id)
        {
            string path = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(path);
            string pathDec = Uri.UnescapeDataString(uri.Path);
            string directoryPath = Path.GetDirectoryName(pathDec) + "\\file.jpg";
            var stream = new FileStream(directoryPath, FileMode.Open, FileAccess.Read);
            return stream;
        }

        public ICollection<CommentView> GetComments(string id)
        {
            var game = _gameService.Get(id);
            var comments = _commentService.GetGameComments(game);
            return Mapper.Map<ICollection<CommentView>>(comments);
        }

        public void CreateComment(CommentView comment)
        {
            var com = Mapper.Map<CommentDTO>(comment);
            _commentService.Create(com);
        }
    }
}