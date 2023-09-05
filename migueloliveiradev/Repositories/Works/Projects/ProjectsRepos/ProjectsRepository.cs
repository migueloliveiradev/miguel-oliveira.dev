using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Repositories.Works.Projects.ProjectsRepos;

public class ProjectsRepository : IProjectsRepository
{
    private readonly DatabaseContext context;
    public ProjectsRepository(DatabaseContext context)
    {
        this.context = context;
    }
    public Project? GetById(int id)
    {
        return context.Projects.FirstOrDefault(p => p.Id == id);
    }
    public Project? GetByIdWithImages(int id)
    {
        return context.Projects.Include(p => p.Images).FirstOrDefault(p => p.Id == id);
    }
    public Project? GetByIdWithTechnologies(int id)
    {
        return context.Projects.Include(p => p.Technologies).FirstOrDefault(p => p.Id == id);
    }
    public Project? GetByIdWithComments(int id)
    {
        return context.Projects.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
    }
    public Project? GetByIdWithImagesAndTechnologies(int id)
    {
        return context.Projects.Include(p => p.Images).Include(p => p.Technologies).FirstOrDefault(p => p.Id == id);
    }
    public Project? GetByIdWithImagesAndComments(int id)
    {
        return context.Projects.Include(p => p.Images).Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
    }
    public Project? GetByIdWithTechnologiesAndComments(int id)
    {
        return context.Projects.Include(p => p.Technologies).Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
    }
    public Project? GetByIdWithImagesAndTechnologiesAndComments(int id)
    {
        return context.Projects.Include(p => p.Images).Include(p => p.Technologies).Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
    }
    public IEnumerable<Technology> GetTechnologies(int id)
    {
        return context.Projects.Where(p => p.Id == id).Select(p => p.Technologies).First().ToList();
    }

    public IEnumerable<Technology> GetTechnologiesNotSelected(int id)
    {
        return context.Technologies
            .Where(t => !context.Projects.Any(p => p.Id == id && p.Technologies.Any(pt => pt.Id == t.Id)))
            .ToList();
    }

    public int GetCount()
    {
        return context.Projects.Count();
    }

    public int GetCountWorking()
    {
        return context.Projects.Where(p => p.Working).Count();
    }

    public IEnumerable<Project> GetAll()
    {
        return context.Projects.ToList();
    }
    public IEnumerable<Project> GetAllWithImages()
    {
        return context.Projects.Include(p => p.Images).ToList();
    }
    public IEnumerable<Project> GetAllWithTechnologies()
    {
        return context.Projects.Include(p => p.Technologies).ToList();
    }
    public IEnumerable<Project> GetAllWithComments()
    {
        return context.Projects.Include(p => p.Comments).ToList();
    }
    public IEnumerable<Project> GetAllWithImagesAndTechnologies()
    {
        return context.Projects.Include(p => p.Images).Include(p => p.Technologies).ToList();
    }
    public IEnumerable<Project> GetAllWithImagesAndComments()
    {
        return context.Projects.Include(p => p.Images).Include(p => p.Comments).ToList();
    }
    public IEnumerable<Project> GetAllWithTechnologiesAndComments()
    {
        return context.Projects.Include(p => p.Technologies).Include(p => p.Comments).ToList();
    }
    public IEnumerable<Project> GetAllWithImagesAndTechnologiesAndComments()
    {
        return context.Projects.Include(p => p.Images).Include(p => p.Technologies).Include(p => p.Comments).ToList();
    }

    public void Create(Project project)
    {
        context.Projects.Add(project);
        context.SaveChanges();
    }

    public void Update(Project project)
    {
        context.Projects.Update(project);
        context.SaveChanges();
    }

    public void AddTechnology(int id, int id_technology)
    {
        ProjectTechnology projectTechnology = new()
        {
            ProjectId = id,
            TechnologyId = id_technology
        };
        
        context.ProjectTechnologies.Add(projectTechnology);
        context.SaveChanges();
    }

    public void RemoveTechnology(int id, int id_technology)
    {
        ProjectTechnology projectTechnology = context.ProjectTechnologies.Where(pt => pt.ProjectId == id && pt.TechnologyId == id_technology).First();
        context.ProjectTechnologies.Remove(projectTechnology);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        context.Projects.Where(p => p.Id == id).ExecuteDelete();
    }
}
