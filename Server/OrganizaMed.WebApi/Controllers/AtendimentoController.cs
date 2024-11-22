using Microsoft.AspNetCore.Mvc;

namespace OrganizaMed.WebApi.Controllers;

public class AtendimentoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}