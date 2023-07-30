using migueloliveiradev.Database;
using migueloliveiradev.ViewsModel;

namespace migueloliveiradev.Repositories.Home;

public class HomeRepository : IHomeRepository
{
    private readonly DatabaseContext context;

    public HomeRepository(DatabaseContext context)
    {
        this.context = context;
    }

    public HomeViewModel GetHomeViewModel()
    {
        return context.About.Select(about => new HomeViewModel()
        {
            Networks = context.SocialNetworks.ToList(),
            About = about,
            Projects = context.Projects.ToList(),
            Services = context.Services.ToList(),
            Technologies = context.Technologies.ToList()
        }).FirstOrDefault();
    }
}
