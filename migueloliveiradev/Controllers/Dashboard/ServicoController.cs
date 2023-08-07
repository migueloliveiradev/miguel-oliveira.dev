using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Repositories.Works.Services;

namespace migueloliveiradev.Controllers.Dashboard;

[Authorize]
public class ServicoController : Controller
{
    private readonly IServiceRepository repository;
    public ServicoController(IServiceRepository serviceRepository)
    {
        repository = serviceRepository;
    }
    [HttpPost("dashboard/services/create")]
    public IActionResult Create(Service service)
    {
        repository.Create(service);
        return RedirectToAction("Servicos", "Dashboard");
    }
    [HttpPost("dashboard/services/edit")]
    public IActionResult Edit(Service service)
    {
        repository.Update(service);
        return RedirectToAction("Servicos", "Dashboard");
    }
    [Route("dashboard/services/{id}/delete")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return RedirectToAction("Servicos", "Dashboard");
    }
}
