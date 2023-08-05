using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using migueloliveiradev.Database;
using migueloliveiradev.Models;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Repositories.Home.Dashboard;
using migueloliveiradev.ViewsModel;

namespace migueloliveiradev.Controllers;

[Authorize]
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
        return RedirectToAction("Home", "Dashboard");
    }
    public IActionResult Home()
    {
        HomeDashboardViewModel homeDashboardViewModel = homeDashboardRepository.GetHomeDashboardViewModel();
        return View(homeDashboardViewModel);
    }

    public IActionResult Servicos()
    {
        List<Service> servicos = context.Services.ToList();
        return View(servicos);
    }
}
