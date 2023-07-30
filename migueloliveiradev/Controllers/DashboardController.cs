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
using migueloliveiradev.Repositories.Home.Dashboard;
using migueloliveiradev.ViewsModel;

namespace migueloliveiradev.Controllers;

//[Authorize]
public class DashboardController : Controller
{
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly DatabaseContext context;
    private readonly IHomeDashboardRepository homeDashboardRepository;

    public DashboardController(SignInManager<IdentityUser> signInManager, DatabaseContext context, IHomeDashboardRepository homeDashboardRepository)
    {
        this.signInManager = signInManager;
        this.context = context;
        this.homeDashboardRepository = homeDashboardRepository;
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
        HomeDashboardViewModel homeDashboardViewModel = homeDashboardRepository.GetHomeDashboardViewModel();
        return View(homeDashboardViewModel);
    }

    public IActionResult Social()
    {
        List<SocialNetwork> redes = context.SocialNetworks.ToList();
        return View(redes);
    }

    public IActionResult Sobre()
    {
        About? about = context.About.FirstOrDefault();
        return View(about);
    }

    public IActionResult Technology()
    {
        List<Technology> skills = context.Technologies.ToList();
        return View(skills);
    }

    public IActionResult Portfolio()
    {
        List<Project> projetos = context.Projects.Include(p => p.Technologies).Include(p => p.Images).ToList();
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
