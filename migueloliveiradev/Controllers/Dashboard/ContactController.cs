using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Me;
using migueloliveiradev.Repositories.Contacts;

namespace migueloliveiradev.Controllers.Dashboard;

[Authorize]
public class ContactController : Controller
{
    private readonly IContactRepository repository;
    public ContactController(IContactRepository contactRepository)
    {
        repository = contactRepository;
    }
    [AllowAnonymous, HttpPost("contacts/create")]
    public IActionResult Create(Contact contact)
    {
        repository.Create(contact);
        return RedirectToAction("Home", "Home");
    }
    [Route("dashboard/contacts/")]
    public IActionResult Home(string? query, Status? status)
    {
        IEnumerable<Contact> contatos = repository.GetQueryFilter(query, status);
        return View("Views/Dashboard/Contacts/Home.cshtml", contatos);
    }

    [Route("dashboard/contacts/{id}/edit/mask_as_read")]
    public IActionResult Read(int id)
    {
        repository.MaskAsRead(id);
        return RedirectToAction("Home", "Contact");
    }
    [Route("dashboard/contacts/{id}/edit/mask_as_unread")]
    public IActionResult Unread(int id)
    {
        repository.MaskAsUnread(id);
        return RedirectToAction("Home", "Contact");
    }
    [Route("dashboard/contacts/{id}/edit/mask_as_answered")]
    public IActionResult Answered(int id)
    {
        repository.MaskAsAnswered(id);
        return RedirectToAction("Home", "Contact");
    }
    [Route("dashboard/contacts/{id}/edit/mask_as_discard")]
    public IActionResult Discard(int id)
    {
        repository.MaskAsDiscarded(id);
        return RedirectToAction("Home", "Contact");
    }
}
