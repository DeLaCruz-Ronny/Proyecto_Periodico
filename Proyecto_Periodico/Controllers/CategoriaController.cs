using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Periodico.Models;

namespace Proyecto_Periodico.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly DBPERIODICOContext context;

        public CategoriaController(DBPERIODICOContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var ls = await context.Categoria.ToListAsync();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            context.Categoria.Add(categoria);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Categoria/Edit/{IdCategoria:int}")]
        public async Task<IActionResult> Edit(int IdCategoria)
        {
            var find = await context.Categoria.FindAsync(IdCategoria);
            return View(find);
        }

        [HttpPost]
        [Route("Categoria/Edit/{IdCategoria:int}")]
        public async Task<IActionResult> Edit(Categoria categoria)
        {
            context.Categoria.Update(categoria);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Categoria/Delete/{IdCategoria:int}")]
        public async Task<IActionResult> Delete(int IdCategoria)
        {
            var find = await context.Categoria.FindAsync(IdCategoria);
            return View(find);
        }

        [HttpPost]
        [Route("Categoria/Delete/{IdCategoria:int}")]
        public async Task<IActionResult> Delete(int? IdCategoria)
        {
            var find = context.Categoria.Find(IdCategoria);
            context.Categoria.Remove(find);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
