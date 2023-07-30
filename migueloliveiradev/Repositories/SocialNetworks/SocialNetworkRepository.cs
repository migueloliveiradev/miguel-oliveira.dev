using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Network;

namespace migueloliveiradev.Repositories.SocialNetworks;

public class SocialNetworkRepository : ISocialNetworkRepository
{
    private readonly DatabaseContext context;
    public SocialNetworkRepository(DatabaseContext context)
    {
        this.context = context;
    }

    public SocialNetwork? GetById(int id)
    {
        return context.SocialNetworks.Find(id);
    }

    public IEnumerable<SocialNetwork> GetAll()
    {
        return context.SocialNetworks.ToList();
    }

    public int GetCount()
    {
        return context.SocialNetworks.Count();
    }

    public void Create(SocialNetwork rede)
    {
        context.SocialNetworks.Add(rede);
        context.SaveChanges();
    }

    public void Update(SocialNetwork rede)
    {
        context.SocialNetworks.Update(rede);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        context.SocialNetworks.Where(p => p.Id == id).ExecuteDelete();
    }
}