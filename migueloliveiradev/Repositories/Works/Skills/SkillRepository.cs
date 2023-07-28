using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Repositories.Works.Skills;

public class SkillRepository : ISkillRepository
{
    private readonly DatabaseContext context;
    public SkillRepository(DatabaseContext context)
    {
        this.context = context;
    }
    public void CreateSkill(Skill skill)
    {
        context.Skills.Add(skill);
        context.SaveChanges();
    }

    public void DeleteSkill(int id)
    {
        context.Skills.Where(p => p.Id == id).ExecuteDelete();
    }
    public Skill? GetSkill(int id)
    {
        return context.Skills.Find(id);
    }
    public IEnumerable<Skill> GetSkills()
    {
        return context.Skills.ToList();
    }
    public void UpdateSkill(Skill skill)
    {
        context.Skills.Update(skill);
        context.SaveChanges();
    }
}
