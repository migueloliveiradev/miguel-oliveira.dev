using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Me;

namespace migueloliveiradev.Controllers.Dashboard
{
    public class ContatoController : Controller
    {
        private readonly DatabaseContext context = new();
        public IActionResult Create(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return View();
        }
        public IActionResult Visible(int id)
        {
            var contact = context.Contacts.Find(id);
            contact.Status = Status.Read;
            context.Contacts.Update(contact);
            context.SaveChanges();
            return Ok();
        }
        public IActionResult Delete(int id)
        {
            context.Contacts.Remove(context.Contacts.Find(id));
            context.SaveChanges();
            return Ok();
        }
        public IActionResult Answered(int id)
        {
            Contact? contact = context.Contacts.Find(id);
            contact.Status = Status.Answered;
            context.Contacts.Update(contact);
            context.SaveChanges();
            return Ok();
        }
    }
}
