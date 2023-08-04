using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Me;
using migueloliveiradev.Repositories.Abouts;

namespace migueloliveiradev.Controllers.Dashboard;

public class AboutController : Controller
{
    private readonly IAboutRepository repository;
    public AboutController(IAboutRepository repository)
    {
        this.repository = repository;
    }
    [Route("dashboard/about")]
    public IActionResult Home()
    {
        About? about = repository.Get();
        return View("Views/Dashboard/About/Home.cshtml", about);
    }

    [HttpPost("dashboard/about/add_or_edit")]
    public IActionResult AddEdit(About about)
    {
        repository.CreateOrUpdate(about);
        return RedirectToAction("Sobre", "Dashboard");
    }
}
