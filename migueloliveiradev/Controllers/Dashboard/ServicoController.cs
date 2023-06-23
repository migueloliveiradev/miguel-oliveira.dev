using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Controllers.Dashboard
{
    public class ServicoController : Controller
    {
        private readonly DatabaseContext context = new();
        public IActionResult Create(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("Servicos", "Dashboard");
        }
        public IActionResult Edit(Service service)
        {
            context.Services.Update(service);
            context.SaveChanges();
            return RedirectToAction("Servicos", "Dashboard");
        }
        public IActionResult Delete(int id)
        {
            Service? service = context.Services.Find(id);
            context.Services.Remove(service);
            context.SaveChanges();
            return RedirectToAction("Servicos", "Dashboard");
        }

    }
}
