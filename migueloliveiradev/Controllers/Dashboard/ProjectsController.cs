﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;
using migueloliveiradev.Repositories.Works.Projects.ProjectsRepos;
using migueloliveiradev.Services.Project;

namespace migueloliveiradev.Controllers.Dashboard;

[Authorize]
public class ProjectsController : Controller
{
    private readonly IProjectsRepository repository;
    private readonly IImageService imageService;
    private readonly DatabaseContext context;
    public ProjectsController(IProjectsRepository repository, DatabaseContext context, IImageService imageService)
    {
        this.repository = repository;
        this.context = context;
        this.imageService = imageService;
    }
    [Route("dashboard/projects")]
    public IActionResult Home()
    {
        IEnumerable<Project> projetos = repository.GetAllWithImagesAndTechnologiesAndComments();
        return View("Views/Dashboard/Projects/Home.cshtml", projetos);
    }
    [Route("dashboard/projects/{id}/edit")]
    public IActionResult Edit(int id)
    {
        Project? projeto = repository.GetById(id);
        if (projeto == null)
        {
            return NotFound();
        }

        return View("Views/Dashboard/Projects/Edit.cshtml", projeto);
    }
    [HttpPost("dashboard/projects/{id}/edit")]
    public IActionResult Edit(int id, Project projeto)
    {
        repository.Update(projeto);
        return RedirectToAction("Home", "Projects");
    }
    [Route("dashboard/projects/{id}/images")]
    public IActionResult Images(int id)
    {
        Project? projeto = repository.GetByIdWithImages(id);
        if (projeto == null)
        {
            return NotFound();
        }

        return View("Views/Dashboard/Projects/Images.cshtml", projeto);
    }
    [HttpPost("dashboard/projects/{id}/image/upload")]
    public async Task<IActionResult> UploadImages(int id, IFormFile file, string description)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            Project projeto = context.Projects.Find(id)!;
            string file_id = Guid.NewGuid().ToString();
            string file_name = $"{file_id}.{file.ContentType.Split('/')[1]}";
            Image image = new()
            {
                Description = description,
                ProjetoId = projeto.Id,
                Name = file_name
            };

            await context.Images.AddAsync(image);
            await context.SaveChangesAsync();
            await imageService.UploadImage(file.OpenReadStream(), file.ContentType, file_id, image.Id);
            transaction.Commit();
        }
        return RedirectToAction("Images", "Projects", new { id });
    }
    [Route("dashboard/projects/{id}/image/delete/{idImage}")]
    public async Task<IActionResult> DeleteImage(int id, int idImage)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            Image image = context.Images.Find(idImage)!;
            await Task.WhenAll(imageService.DeleteImage(image.Name));
            context.Images.Remove(image);
            context.SaveChanges();
            transaction.Commit();
        }
        return RedirectToAction("Images", "Projects", new { id });
    }
    [Route("dashboard/projects/{id}/comments")]
    public IActionResult Comments(int id)
    {
        Project? projeto = repository.GetByIdWithComments(id);
        if (projeto == null)
        {
            return NotFound();
        }

        return View("Views/Dashboard/Projects/Comments.cshtml", projeto);
    }
    [Route("dashboard/projects/{id}/tecnologies")]
    public IActionResult Tecnologies(int id)
    {
        Project? projeto = repository.GetByIdWithTechnologies(id);
        if (projeto == null)
        {
            return NotFound();
        }
        IEnumerable<Technology> tecs = repository.GetTechnologiesNotSelected(id);

        return View("Views/Dashboard/Projects/Tecnologies.cshtml", (projeto, tecs));
    }
    [Route("dashboard/projects/{id}/tecnologies/{id_tech}/add")]
    public IActionResult AddTechnology(int id, int id_tech)
    {
        repository.AddTechnology(id, id_tech);
        return RedirectToAction("Tecnologies", "Projects", new { id });
    }
    [Route("dashboard/projects/{id}/tecnologies/{id_tech}/remove")]
    public IActionResult RemoveTechnology(int id, int id_tech)
    {
        repository.RemoveTechnology(id, id_tech);
        return RedirectToAction("Tecnologies", "Projects", new { id });
    }
    [HttpPost("dashboard/projects/create")]
    public IActionResult Create(Project projeto)
    {
        repository.Create(projeto);
        return RedirectToAction("Home", "Projects");
    }
    [Route("dashboard/projects/update")]
    public IActionResult Update(Project projeto)
    {
        repository.Update(projeto);
        return RedirectToAction("Home", "Projects");
    }
    [Route("dashboard/projects/delete/{id}")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return RedirectToAction("Home", "Projects");
    }
}
