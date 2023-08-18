using migueloliveiradev.Repositories.Abouts;
using migueloliveiradev.Repositories.SocialNetworks;
using migueloliveiradev.Repositories.Works.Projects.ProjectsRepos;
using migueloliveiradev.Repositories.Works.Projects.Technologies;
using migueloliveiradev.ViewsModel;

namespace migueloliveiradev.Repositories.Home;

public class HomeRepository : IHomeRepository
{
    private readonly IAboutRepository aboutRepository;
    private readonly ISocialNetworkRepository socialNetworkRepository;
    private readonly ITechnologyRepository technologyRepository;
    private readonly IProjectsRepository projectsRepository;

    public HomeRepository(IAboutRepository aboutRepository,
        ISocialNetworkRepository socialNetworkRepository,
        ITechnologyRepository technologyRepository,
        IProjectsRepository projectsRepository)
    {
        this.aboutRepository = aboutRepository;
        this.socialNetworkRepository = socialNetworkRepository;
        this.technologyRepository = technologyRepository;
        this.projectsRepository = projectsRepository;
    }

    public HomeViewModel GetHomeViewModel()
    {
        return new HomeViewModel()
        {
            About = aboutRepository.Get(),
            SocialNetworks = socialNetworkRepository.GetAll(),
            Projects = projectsRepository.GetAllWithImagesAndTechnologies(),
            Technologies = technologyRepository.GetAll()
        };
    }
}
