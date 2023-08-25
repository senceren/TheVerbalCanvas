using Microsoft.AspNetCore.Mvc;

namespace TheVerbalCanvas.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
