using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Repositories.Works.Projects.ProjectsRepos;

public interface IProjectsRepository
{
    Project? GetById(int id);
    Project? GetByIdWithImages(int id);
    Project? GetByIdWithTechnologies(int id);
    Project? GetByIdWithComments(int id);
    Project? GetByIdWithImagesAndTechnologies(int id);
    Project? GetByIdWithImagesAndComments(int id);
    Project? GetByIdWithTechnologiesAndComments(int id);
    Project? GetByIdWithImagesAndTechnologiesAndComments(int id);
    IEnumerable<Technology> GetTechnologies(int id);
    IEnumerable<Technology> GetTechnologiesNotSelected(int id);
    int GetCount();
    int GetCountWorking();
    IEnumerable<Project> GetAll();
    IEnumerable<Project> GetAllWithImages();
    IEnumerable<Project> GetAllWithTechnologies();
    IEnumerable<Project> GetAllWithComments();
    IEnumerable<Project> GetAllWithImagesAndTechnologies();
    IEnumerable<Project> GetAllWithImagesAndComments();
    IEnumerable<Project> GetAllWithTechnologiesAndComments();
    IEnumerable<Project> GetAllWithImagesAndTechnologiesAndComments();
    void Create(Project project);
    void Update(Project project);
    void AddTechnology(int id, int id_technology);
    void RemoveTechnology(int id, int id_technology);
    void Delete(int id);
}
