using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;

namespace migueloliveiradev.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        public HomeController(DatabaseContext context)
        {
              _context = context;
        }
        [Route("/")]
        public IActionResult Home()
        {
            DatabaseContext context = new();
            ViewData["social-links"] = _context.RedeSociais.ToList();
            return View();
        }
    }
}