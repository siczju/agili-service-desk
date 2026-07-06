using AgiliServiceDesk.Data;
using AgiliServiceDesk.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            ViewBag.ChamadosConcluidos = _context.Chamados
                .Count(c => c.Status == StatusChamado.Concluido);

            ViewBag.ChamadosAbertos = _context.Chamados
                .Count(c => c.Status == StatusChamado.Aberto);

            ViewBag.ChamadosEmAndamento = _context.Chamados
                .Count(c => c.Status == StatusChamado.EmAndamento);

            return View();
        }
    }
}