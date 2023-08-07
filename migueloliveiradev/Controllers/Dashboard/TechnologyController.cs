using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Repositories.Works.Projects.Technologies;

namespace migueloliveiradev.Controllers.Dashboard;

[Authorize]
public class TechnologyController : Controller
{
    private readonly ITechnologyRepository repository;
    public TechnologyController(ITechnologyRepository repository)
    {
        this.repository = repository;
    }

    [Route("dashboard/technologies")]
    public IActionResult Home()
    {
        IEnumerable<Technology> technologies = repository.GetAllWithProjects();
        return View("Views/Dashboard/Technology/Home.cshtml", technologies);
    }

    [HttpPost(), Route("dashboard/technologies/create")]
    public IActionResult Create(Technology technology)
    {
        repository.Create(technology);
        return RedirectToAction("Home", "Technology");
    }

    [HttpPost(), Route("dashboard/technologies/edit")]
    public IActionResult Edit(Technology technology)
    {

        return RedirectToAction("Technology", "Dashboard");
    }

    [Route("dashboard/technologies/{id}/delete")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return RedirectToAction("Technology", "Dashboard");
    }
}
