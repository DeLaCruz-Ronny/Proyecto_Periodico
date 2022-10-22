using Microsoft.AspNetCore.Mvc;
using Proyecto_Periodico.Models;

namespace Proyecto_Periodico.Controllers
{
    public class LoginController : Controller
    {
        private readonly DBPERIODICOContext context;

        public LoginController(DBPERIODICOContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario _usuario)
        {
            var acceso = context.Usuarios.Where(x => x.Correo == _usuario.Correo && x.Clave == _usuario.Clave).FirstOrDefault();
            if (acceso != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Salir()
        {
            return RedirectToAction("Index", "Principal");
        }

    }
}
