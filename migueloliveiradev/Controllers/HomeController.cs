using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;

namespace migueloliveiradev.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Home()
        {
            DatabaseContext context = new();
            ViewData["social-links"] = context.RedeSociais.ToList();
            return View();
        }
    }
}