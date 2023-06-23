using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Works.Projetos;
using migueloliveiradev.Services.Projeto;
using Oci.ObjectstorageService.Requests;

namespace migueloliveiradev.Controllers.Dashboard
{
    public class ProjetoController : Controller
    {
        private readonly DatabaseContext context = new();

        public IActionResult GetSkillsProjeto(int idProjeto)
        {
            return Json(context.Projetos.Find(idProjeto)?.Tecnologias);
        }

        public IActionResult GetProjeto(int id)
        {
            return Ok(context.Projetos.Find(id));
        }
        public IActionResult Create(Projeto projeto)
        {
            context.Projetos.Add(projeto);
            context.SaveChanges();
            return RedirectToAction("Portfolio", "Dashboard");
        }
        public IActionResult Update(Projeto projeto)
        {
            context.Projetos.Update(projeto);
            context.SaveChanges();
            return Ok();
        }
        public IActionResult Delete(int id)
        {
            context.Projetos.Remove(context.Projetos.Find(id));
            context.SaveChanges();
            return Ok();
        }
        public IActionResult ListTechnologies(int id)
        {
            return Ok(context.Projetos.Find(id)?.Tecnologias);
        }
        public IActionResult AddTechnology(int id, int idTecnologia)
        {
            Projeto? projeto = context.Projetos.Find(id);
            Tecnologia? tecnologia = context.Tecnologias.Find(idTecnologia);
            projeto?.Tecnologias.Add(tecnologia);
            context.Projetos.Update(projeto);
            context.SaveChanges();
            return Ok();
        }
        public async Task<IActionResult> AddImages(int projectId, List<IFormFile> files)
        {
            Projeto? projeto = context.Projetos.Find(projectId);
            foreach (var file in files)
            {
                projeto.Imagens.Add(new Imagem()
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
            Imagem? imagem = context.Imagens.Find(id);
            await ImagemService.DeleteImageStorage(imagem.Url);
            context.Imagens.Remove(imagem);
            context.SaveChanges();
            return Ok();
        }
    }
}
