using Microsoft.AspNetCore.Mvc;
using WorldRecipes.Models;

namespace WorldRecipes.Controllers
{
    public class AdminController : Controller
    {
        private readonly ModelContext _context;

        public AdminController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("AdminId");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(" ", " ");
        }
    }
}
