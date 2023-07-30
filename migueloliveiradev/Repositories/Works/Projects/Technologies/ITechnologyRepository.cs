using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Repositories.Works.Projects.Technologies;

public interface ITechnologyRepository
{
    Technology? GetById(int id);
    Technology? GetByIdWithProjects(int id);
    IEnumerable<Technology> GetAll();
    IEnumerable<Technology> GetAllWithProjects();
    int GetCount();
    void Create(Technology tecnologia);
    void Update(Technology tecnologia);
    void Delete(int id);
}
