using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Periodico.Models;
using Proyecto_Periodico.Models.ViewModel;
using System.Dynamic;

namespace Proyecto_Periodico.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly DBPERIODICOContext context;

        public UsuariosController(DBPERIODICOContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var ls = await context.Usuarios.ToListAsync();
            return View(ls);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Route("Usuarios/Edit/{IdUsuario:int}")]
        public async Task<IActionResult> Edit(int IdUsuario)
        {
            var usuario = await context.Usuarios.FindAsync(IdUsuario);
            return View(usuario);
        }

        [HttpPost]
        [Route("Usuarios/Edit/{IdUsuario:int}")]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Route("Usuarios/Delete/{IdUsuario:int}")]
        public async Task<IActionResult> Delete(int IdUsuario)
        {
            var usuario = await context.Usuarios.FindAsync(IdUsuario);
            return View(usuario);
        }

        [HttpPost]
        [Route("Usuarios/Delete/{IdUsuario:int}")]
        public IActionResult Delete(int? IdUsuario)
        {
            var lb = context.Usuarios.Find(IdUsuario);
            context.Usuarios.Remove(lb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
