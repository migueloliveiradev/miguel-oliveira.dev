using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Repositories.Works.Projects.Technologies;

namespace migueloliveiradev.Controllers.Dashboard;
public class TechnologyController : Controller
{
    private readonly ITechnologyRepository repository;
    public TechnologyController(ITechnologyRepository repository)
    {
        this.repository = repository;
    }

    [Route("dashboard/technologies")]
    public IActionResult Technologies()
    {
        IEnumerable<Technology> technologies = repository.GetAllWithProjects();
        return View(technologies);
    }
    [HttpPost(), Route("dashboard/technologies/create")]
    public IActionResult Create(Technology technology)
    {
        repository.Create(technology);
        return RedirectToAction("Technology", "Dashboard");
    }
    [HttpPost(), Route("dashboard/technologies/edit")]
    public IActionResult Edit(Technology technology)
    {

        return RedirectToAction("Technology", "Dashboard");
    }
    [Route("dashboard/technologies/delete/{id}")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return RedirectToAction("Technology", "Dashboard");
    }
}
