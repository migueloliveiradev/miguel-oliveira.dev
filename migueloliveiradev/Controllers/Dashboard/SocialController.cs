using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Network;

namespace migueloliveiradev.Controllers.Dashboard
{
    public class SocialController : Controller
    {
        private readonly DatabaseContext context = new();
        public IActionResult Create(RedeSocial rede)
        {
            context.RedeSociais.Add(rede);
            context.SaveChanges();
            return RedirectToAction("Social", "Dashboard");
        }
        public IActionResult Edit(RedeSocial rede)
        {
            context.RedeSociais.Update(rede);
            context.SaveChanges();
            return RedirectToAction("Social", "Dashboard");
        }
        public IActionResult Delete(int id)
        {
            RedeSocial? rede = context.RedeSociais.Find(id);
            context.RedeSociais.Remove(rede);
            context.SaveChanges();
            return RedirectToAction("Social", "Dashboard");
        }

    }
}
