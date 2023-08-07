using migueloliveiradev.Database;
using migueloliveiradev.Models.Me;

namespace migueloliveiradev.Repositories.Abouts;

public class AboutRepository : IAboutRepository
{
    private readonly DatabaseContext context;
    public AboutRepository(DatabaseContext context)
    {
        this.context = context;
    }
    public About? Get()
    {
        return context.About.FirstOrDefault();
    }
    public void CreateOrUpdate(About about)
    {
        if (about.Id == 0)
            context.About.Add(about);
        else
            context.About.Update(about);
        context.SaveChanges();
    }
}
