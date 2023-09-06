using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Repositories.Works.Projects.Technologies;
using migueloliveiradev.Services.Storage;

namespace migueloliveiradev.Controllers.Dashboard;

[Authorize]
public class TechnologyController : Controller
{
    private readonly ITechnologyRepository repository;
    private readonly IStorageService storageService;
    public TechnologyController(ITechnologyRepository repository, IStorageService storageService)
    {
        this.repository = repository;
        this.storageService = storageService;
    }

    [Route("dashboard/technologies")]
    public IActionResult Home()
    {
        IEnumerable<Technology> technologies = repository.GetAllWithProjects();
        return View("Views/Dashboard/Technology/Home.cshtml", technologies);
    }

    [HttpPost(), Route("dashboard/technologies/create")]
    public async Task<IActionResult> Create(Technology technology, IFormFile svg)
    {
        if (string.IsNullOrEmpty(technology.Icon))
        {
            string file_id = Guid.NewGuid().ToString();
            technology.Icon = $"{file_id}.svg";
            await storageService.UploadImage(svg.OpenReadStream(), svg.ContentType, technology.Icon);
        }
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
