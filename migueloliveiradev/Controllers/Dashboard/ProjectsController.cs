using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;
using migueloliveiradev.Repositories.Works.Projects.ProjectsRepos;

namespace migueloliveiradev.Controllers.Dashboard;

public class ProjectsController : Controller
{
    private readonly IProjectsRepository repository;
    public ProjectsController(IProjectsRepository repository)
    {
        this.repository = repository;
    }
    [Route("dashboard/projects/{id}/tecnologies/get")]
    public IActionResult GetTechnologiesProjeto(int id)
    {
        IEnumerable<Technology> techs = repository.GetTechnologies(id);
        IEnumerable<Technology> techs2 = repository.GetTechnologiesNotSelected(id);
        return Json(new
        {
            technology = techs,
            technology_not_selected = techs2
        });
    }
    [Route("dashboard/projects/{id}")]
    public IActionResult GetProjeto(int id)
    {
        Project? projeto = repository.GetById(id);
        return Ok(projeto);
    }
    [Route("dashboard/projects/create")]
    public IActionResult Create(Project projeto)
    {
        repository.Create(projeto);
        return RedirectToAction("Portfolio", "Dashboard");
    }
    [Route("dashboard/projects/update")]
    public IActionResult Update(Project projeto)
    {
        repository.Update(projeto);
        return Ok();
    }
    [Route("dashboard/projects/delete/{id}")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return Ok();
    }
    [Route("dashboard/projects/{id}/tecnologies/add/{idTecnologia}")]
    public IActionResult AddTechnology(int id, int idTecnologia)
    {
        repository.AddTechnology(id, idTecnologia);
        return Ok();
    }
    /*public async Task<IActionResult> AddImages(int projectId, List<IFormFile> files)
    {
        Project? projeto = context.Projetos.Find(projectId);
        foreach (var file in files)
        {
            projeto.Imagens.Add(new Image()
            {
                Descricao = file.FileName,
                Url = await ImagemService.AddImageStorage(file.OpenReadStream(), file.ContentType)
            });
        }
        context.Projetos.Update(projeto);
        context.SaveChanges();
        return Ok();
    }
    public async Task<IActionResult> RemoveImage(int id)
    {
        Image? imagem = context.Imagens.Find(id);
        await ImagemService.DeleteImageStorage(imagem.Url);
        context.Imagens.Remove(imagem);
        context.SaveChanges();
        return Ok();
    }*/
}
