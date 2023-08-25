using Microsoft.AspNetCore.Mvc;
using TheVerbalCanvas.Data;

namespace TheVerbalCanvas.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext db;

        public PostController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index(int id)
        {
            var post = db.Posts.Find(id);
            if(post == null) 
                return NotFound();

            return View(post);
        }
    }
}
