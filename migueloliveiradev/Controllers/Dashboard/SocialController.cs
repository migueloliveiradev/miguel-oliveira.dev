using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Network;
using migueloliveiradev.Repositories.SocialNetworks;

namespace migueloliveiradev.Controllers.Dashboard;

public class SocialController : Controller
{
    private readonly ISocialNetworkRepository repository;
    public SocialController(ISocialNetworkRepository repository)
    {
        this.repository = repository;
    }
    [HttpPost("dashboard/social/create")]
    public IActionResult Create(SocialNetwork social)
    {
        repository.Create(social);
        return RedirectToAction("Social", "Dashboard");
    }
    [HttpPost("dashboard/social/edit")]
    public IActionResult Edit(SocialNetwork social)
    {
        repository.Update(social);
        return RedirectToAction("Social", "Dashboard");
    }
    [Route("dashboard/social/{id}/delete")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return RedirectToAction("Social", "Dashboard");
    }
}
