using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Repositories.Works.Services;

public interface IServiceRepository
{
    IEnumerable<Models.Works.Service> GetServices();
    Service GetService(int id);
    void CreateService(Service service);
    void UpdateService(Service service);
    void DeleteService(int id);
}
