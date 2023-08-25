using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheVerbalCanvas.Data;
using TheVerbalCanvas.Models;

namespace TheVerbalCanvas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Posts.OrderByDescending(x => x.Id).ToList());
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