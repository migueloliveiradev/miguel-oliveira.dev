using migueloliveiradev.Models.Me;

namespace migueloliveiradev.Repositories.Abouts;

public interface IAboutRepository
{
    About Get();
    void CreateOrUpdate(About about);
}
