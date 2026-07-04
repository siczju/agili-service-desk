using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgiliServiceDesk.Data;

namespace AgiliServiceDesk.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalChamados = _context.Chamados.Count();

            ViewBag.TotalCategorias = _context.Categorias.Count();

            ViewBag.UltimosChamados = _context.Chamados
                .Include(c => c.Categoria)
                .OrderByDescending(c => c.DataAbertura)
                .Take(5)
                .ToList();

            return View();
        }
    }
}