using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Me;
using migueloliveiradev.Repositories.Contacts;

namespace migueloliveiradev.Controllers.Dashboard;

public class ContactController : Controller
{
    private readonly IContactRepository repository;
    public ContactController(IContactRepository contactRepository)
    {
        repository = contactRepository;
    }
    [HttpPost("contacts/create")]
    public IActionResult Create(Contact contact)
    {
        repository.Create(contact);
        return View();
    }
    [Route("dashboard/contacts/{id}/edit/mask_as_read")]
    public IActionResult Visible(int id)
    {
        repository.MaskAsRead(id);
        return Ok();
    }
    [Route("dashboard/contacts/{id}/delete")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return Ok();
    }
    [Route("dashboard/contacts/{id}/edit/mask_as_answered")]
    public IActionResult Answered(int id)
    {
        repository.MaskAsAnswered(id);
        return Ok();
    }
}
