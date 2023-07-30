using migueloliveiradev.Models.Me;
using migueloliveiradev.Models.Network;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.ViewsModel;

public class HomeViewModel
{
    public IEnumerable<SocialNetwork> Networks { get; set; }
    public About? About { get; set; }
    public IEnumerable<Project> Projects { get; set; }
    public IEnumerable<Service> Services { get; set; }
    public IEnumerable<Technology> Technologies { get; set; }
}
