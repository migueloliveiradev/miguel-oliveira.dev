using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Me;
using migueloliveiradev.Repositories.Abouts;

namespace migueloliveiradev.Controllers.Dashboard;

[Route("dashboard")]
public class AboutController : Controller
{
    private readonly IAboutRepository repository;
    public AboutController(IAboutRepository repository)
    {
        this.repository = repository;
    }

    [HttpPost("add_or_edit")]
    public IActionResult AddEdit(About about)
    {
        repository.CreateOrUpdate(about);
        return RedirectToAction("Sobre", "Dashboard");
    }
}
