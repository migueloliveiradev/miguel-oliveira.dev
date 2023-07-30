using migueloliveiradev.Repositories.Contacts;
using migueloliveiradev.Repositories.SocialNetworks;
using migueloliveiradev.Repositories.Works.Projects.ProjectsRepos;
using migueloliveiradev.Repositories.Works.Projects.Technologies;
using migueloliveiradev.Repositories.Works.Services;
using migueloliveiradev.ViewsModel;

namespace migueloliveiradev.Repositories.Home.Dashboard;

public class HomeDashboardRepository : IHomeDashboardRepository
{
    private readonly IProjectsRepository projectsRepository;
    private readonly IContactRepository contactRepository;
    private readonly ISocialNetworkRepository socialNetworkRepository;
    private readonly ITechnologyRepository technologyRepository;
    private readonly IServiceRepository serviceRepository;

    public HomeDashboardRepository(IProjectsRepository projectsRepository,
        IContactRepository contactRepository,
        ISocialNetworkRepository socialNetworkRepository,
        ITechnologyRepository technologyRepository,
        IServiceRepository serviceRepository)
    {
        this.projectsRepository = projectsRepository;
        this.contactRepository = contactRepository;
        this.socialNetworkRepository = socialNetworkRepository;
        this.technologyRepository = technologyRepository;
        this.serviceRepository = serviceRepository;
    }

    public HomeDashboardViewModel GetHomeDashboardViewModel()
    {
        return new HomeDashboardViewModel
        {
            ProjectsCount = projectsRepository.GetCount(),
            ProjectsWorkingCount = projectsRepository.GetCountWorking(),
            ContactsCount = contactRepository.GetCount(),
            ContactsUnreadCount = contactRepository.GetCountUnread(),
            SocialNetworksCount = socialNetworkRepository.GetCount(),
            TechnologiesCount = technologyRepository.GetCount(),
            ServicesCount = serviceRepository.GetCount()
        };
    }
}
