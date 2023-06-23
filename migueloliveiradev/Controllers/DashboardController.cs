using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models;
using migueloliveiradev.Models.Me;
using migueloliveiradev.Models.Network;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Controllers
{
    //[Authorize]
    public class DashboardController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly DatabaseContext context = new();

        public DashboardController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return PartialView(new Usuario());
        }
        [AllowAnonymous, HttpPost()]
        public async Task<IActionResult> Login(Usuario usuario, bool lembrar)
        {
            await signInManager.PasswordSignInAsync(usuario.Username, usuario.Senha, lembrar, false);
            return RedirectToAction("Login", "Dashboard");
        }
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Social()
        {
            List<RedeSocial> redes = context.RedeSociais.ToList();
            return View(redes);
        }

        public IActionResult Sobre()
        {
            About? about = context.About.FirstOrDefault();
            return View(about);
        }

        public IActionResult Skills()
        {
            List<Skill> skills = context.Skills.ToList();
            return View(skills);
        }

        public IActionResult Portfolio()
        {
            List<Projeto> projetos = context.Projetos.Include(p => p.Tecnologias).Include(p=> p.Imagens).ToList();
            return View(projetos);
        }

        public IActionResult Servicos()
        {
            List<Service> servicos = context.Services.ToList();
            return View(servicos);
        }

        public IActionResult Contatos(string query, Status status)
        {
            //create query to search
            List<Contact> contatos = context.Contacts.ToList();
            return View(contatos);
        }
    }
}
