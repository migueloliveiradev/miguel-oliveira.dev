using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Repositories.Works.Services;

public interface IServiceRepository
{
    Service GetById(int id);
    IEnumerable<Service> GetAll();
    int GetCount();
    void Create(Service service);
    void Update(Service service);
    void Delete(int id);
}
