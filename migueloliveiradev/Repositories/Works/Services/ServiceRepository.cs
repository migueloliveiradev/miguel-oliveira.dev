using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Repositories.Works.Services;

public class ServiceRepository : IServiceRepository
{
    private readonly DatabaseContext context;
    public ServiceRepository(DatabaseContext context)
    {
        this.context = context;
    }

    public Service? GetById(int id)
    {
        return context.Services.Find(id);
    }
    public IEnumerable<Service> GetAll()
    {
        return context.Services.ToList();
    }

    public int GetCount()
    {
        return context.Services.Count();
    }

    public void Create(Service service)
    {
        context.Services.Add(service);
        context.SaveChanges();
    }

    public void Update(Service service)
    {
        context.Services.Update(service);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        context.Services.Where(p => p.Id == id).ExecuteDelete();
    }
}
