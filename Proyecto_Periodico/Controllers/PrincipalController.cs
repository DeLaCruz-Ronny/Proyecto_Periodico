using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Periodico.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
