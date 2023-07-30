using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Repositories.Works.Projects.Images;

public class ImagesRepository : IImagesRepository
{
    private readonly DatabaseContext context;
    public ImagesRepository(DatabaseContext context)
    {
        this.context = context;
    }
    public Image? GetById(int id)
    {
        return context.Images.FirstOrDefault(x => x.Id == id);
    }
    public IEnumerable<Image> GetAll()
    {
        return context.Images.ToList();
    }
    public void Create(Image image)
    {
        context.Images.Add(image);
        context.SaveChanges();
    }
    public void Update(Image image)
    {
        context.Images.Update(image);
        context.SaveChanges();
    }
    public void Delete(int id)
    {
        context.Images.Where(p => p.Id == id).ExecuteDelete();
    }
}
