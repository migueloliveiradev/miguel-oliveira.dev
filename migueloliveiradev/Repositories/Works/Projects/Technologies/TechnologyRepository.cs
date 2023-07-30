using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Repositories.Works.Projects.Technologies;

public class TechnologyRepository : ITechnologyRepository
{
    private readonly DatabaseContext context;
    public TechnologyRepository(DatabaseContext context)
    {
        this.context = context;
    }
    public Technology? GetById(int id)
    {
        return context.Technologies.FirstOrDefault(p => p.Id == id);
    }
    public Technology? GetByIdWithProjects(int id)
    {
        return context.Technologies.Include(p => p.Projetos).FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Technology> GetAll()
    {
        return context.Technologies.ToList();
    }
    public IEnumerable<Technology> GetAllWithProjects()
    {
        return context.Technologies.Include(p => p.Projetos).ToList();
    }

    public int GetCount()
    {
        return context.Technologies.Count();
    }

    public void Create(Technology technology)
    {
        context.Technologies.Add(technology);
        context.SaveChanges();
    }

    public void Update(Technology technology)
    {
        context.Technologies.Update(technology);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        context.Technologies.Where(p => p.Id == id).ExecuteDelete();
    }
}
