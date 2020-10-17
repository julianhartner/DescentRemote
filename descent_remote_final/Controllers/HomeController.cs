using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using descent_remote_final.Models;
using descent_remote_final.Services;
using descent_remote_final.ViewModels;
using System.Linq;

namespace descent_remote_final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameHandler _gameHandler;

        public HomeController(ILogger<HomeController> logger, GameHandler gameHandler)
        {
            _logger = logger;
            _gameHandler = gameHandler;
        }

        public IActionResult Index()
        {
            return View(_gameHandler.Users);
        }

        public IActionResult Character(string username)
        {
            var user = _gameHandler.Users.FirstOrDefault(u => u.Name == username);
            return View(new DashboardUserViewModel(user));
        }

        public IActionResult Overlord(string username)
        {
            var user = _gameHandler.Users.FirstOrDefault(u => u.Name == username);
            return View(new OverlordUserViewModel(user));
        }

        public IActionResult Cookie(string id)
        {
            var user = _gameHandler.Users.FirstOrDefault(u => u.Id == id);

            Response.Cookies.Append("id", id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
