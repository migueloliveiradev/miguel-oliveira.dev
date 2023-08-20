using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Network;
using migueloliveiradev.Repositories.SocialNetworks;

namespace migueloliveiradev.Controllers.Dashboard;

[Authorize]
public class SocialController : Controller
{
    private readonly ISocialNetworkRepository repository;
    public SocialController(ISocialNetworkRepository repository)
    {
        this.repository = repository;
    }

    [Route("dashboard/socials")]
    public IActionResult Home()
    {
        IEnumerable<SocialNetwork> socials = repository.GetAll();
        return View("Views/Dashboard/Social/Home.cshtml", socials);
    }


    [HttpPost("dashboard/social/create")]
    public IActionResult Create(SocialNetwork social)
    {
        repository.Create(social);
        return RedirectToAction("Home", "Social");
    }

    [HttpPost("dashboard/social/edit")]
    public IActionResult Edit(SocialNetwork social)
    {
        repository.Update(social);
        return RedirectToAction("Home", "Social");
    }

    [Route("dashboard/social/{id}/delete")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return RedirectToAction("Home", "Social");
    }
}
