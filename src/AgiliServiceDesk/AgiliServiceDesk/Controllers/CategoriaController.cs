using Microsoft.AspNetCore.Mvc;
using AgiliServiceDesk.Data;
using AgiliServiceDesk.Models;

namespace AgiliServiceDesk.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public IActionResult Edit(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        public IActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Delete(Categoria categoria)
        {
            var existente = _context.Categorias.FirstOrDefault(x => x.Id == categoria.Id);

            if (existente == null)
                return NotFound();

            _context.Categorias.Remove(existente);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
