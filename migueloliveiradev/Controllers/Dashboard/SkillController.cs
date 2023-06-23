using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Controllers.Dashboard
{
    public class SkillController : Controller
    {
        private readonly static DatabaseContext context = new();

        public IActionResult Create(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Skills", "Dashboard");
        }

        public IActionResult Edit(Skill skill)
        {
            context.Skills.Update(skill);
            context.SaveChanges();
            return RedirectToAction("Skills", "Dashboard");
        }
        public IActionResult Delete(int id)
        {
            Skill? skill = context.Skills.Find(id);
            context.Skills.Remove(skill);
            context.SaveChanges();
            return RedirectToAction("Skills", "Dashboard");
        }
    }
}
