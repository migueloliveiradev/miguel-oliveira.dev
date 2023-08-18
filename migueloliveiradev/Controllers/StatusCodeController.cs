using Microsoft.AspNetCore.Mvc;

namespace migueloliveiradev.Controllers;
public class StatusCodeController : Controller
{
    [Route("404")]
    public IActionResult NotFoundPage()
    {
        return View("Views/StatusCode/404.cshtml");
    }
}
