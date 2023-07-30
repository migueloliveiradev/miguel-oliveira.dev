using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Repositories.Works.Projects.Images;

public interface IImagesRepository
{
    Image GetById(int id);
    IEnumerable<Image> GetAll();
    void Create(Image image);
    void Update(Image image);
    void Delete(int id);
}
