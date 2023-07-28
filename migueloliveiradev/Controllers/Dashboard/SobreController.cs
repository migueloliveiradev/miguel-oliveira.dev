using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Me;

namespace migueloliveiradev.Controllers.Dashboard;

public class SobreController : Controller
{
    private readonly DatabaseContext context = new();
    public IActionResult AddEdit(About about)
    {
        if (context.About.Any())
        {
            context.About.Update(about);
            context.SaveChanges();
        }
        else
        {
            context.About.Add(about);
            context.SaveChanges();
        }
        return RedirectToAction("Sobre", "Dashboard");
    }
}
