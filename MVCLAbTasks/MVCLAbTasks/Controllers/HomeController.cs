using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Services.Interfaces;

namespace MVCLAbTasks.Controllers
{
    public class HomeController : Controller
    {
        /*private IGameService _gameService;

        public HomeController(IGameService service)
        {
            _gameService = service;
        }*/

        // GET: Home
        public ActionResult Index()
        {
            // ICollection<GameDTO> games = _gameService.GetAll();
            // return View(null);
            return View();
        }

    }
}