using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using MVCLAbTasks.Models.Entities;
using BusinessLogicLayer.Services.Interfaces;
using MVCLAbTasks.Models.Infrastructure;

namespace MVCLAbTasks.Controllers
{
    public class GamesController : ApiController
    {
        private readonly GamesProxy _gamesServiceProxy;

        public GamesController(IGameService gameService, ICommentService commentService)
        {
            _gamesServiceProxy = new GamesProxy(gameService, commentService);
        }

        public ICollection<GameView> Get()
        {
            return _gamesServiceProxy.GetAllGames();
        }

        [Route("api/game/{id}")]
        public GameView Get(string id)
        {
            return _gamesServiceProxy.Get(id);
        }

        public void PostCreate([FromBody]GameView game)
        {
            _gamesServiceProxy.CreateGame(game);
        }

        [Route("api/games/update")]
        public void Update([FromBody]GameView game)
        {
            _gamesServiceProxy.UpdateGame(game);
        }

        [Route("api/games/remove")]
        public void Remove([FromBody]GameView game)
        {
            _gamesServiceProxy.RemoveGame(game);
        }
        
        [Route("api/game/{id}/download")]
        public HttpResponseMessage GetContent(string id)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = _gamesServiceProxy.GetGameStream(id);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        [Route("api/game/{id}/comments")]
        public ICollection<CommentView> GetComments(string id)
        {
            return _gamesServiceProxy.GetComments(id);
        }


        [Route("api/game/{id}/newcomment")]
        public void PostComment(CommentView comment)
        {
            _gamesServiceProxy.CreateComment(comment);
        }
    }
}