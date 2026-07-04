using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgiliServiceDesk.Data;
using AgiliServiceDesk.Models;

namespace AgiliServiceDesk.Controllers
{
    public class ChamadoController : Controller
    {
        private readonly AppDbContext _context;

        public ChamadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Chamado
        public IActionResult Index()
        {
            var chamados = _context.Chamados
                .Include(c => c.Categoria)
                .OrderByDescending(c => c.DataAbertura)
                .ToList();

            return View(chamados);
        }

        // GET: /Chamado/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return NotFound();

            var chamado = _context.Chamados
                .Include(c => c.Categoria)
                .FirstOrDefault(c => c.Id == id.Value);

            if (chamado == null) return NotFound();

            return View(chamado);
        }

        // GET: /Chamado/Create
        public IActionResult Create()
        {
            var vm = new ChamadoFormViewModel
            {
                Chamado = new Chamado { DataAbertura = DateTime.UtcNow },
                Categorias = _context.Categorias.OrderBy(c => c.Nome).ToList()
            };
            return View(vm);
        }

        // POST: /Chamado/Create
        [HttpPost]
        public IActionResult Create(Chamado chamado)
        {
            if (!ModelState.IsValid)
            {
                var vm = new ChamadoFormViewModel
                {
                    Chamado = chamado,
                    Categorias = _context.Categorias.OrderBy(c => c.Nome).ToList()
                };
                return View(vm);
            }

            chamado.DataAbertura = DateTime.UtcNow;
            _context.Chamados.Add(chamado);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Chamado/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return NotFound();

            var chamado = _context.Chamados.Find(id.Value);
            if (chamado == null) return NotFound();

            var vm = new ChamadoFormViewModel
            {
                Chamado = chamado,
                Categorias = _context.Categorias.OrderBy(c => c.Nome).ToList()
            };
            return View(vm);
        }

        // POST: /Chamado/Edit
        [HttpPost]
        public IActionResult Edit(Chamado chamado)
        {
            if (!ModelState.IsValid)
            {
                var vm = new ChamadoFormViewModel
                {
                    Chamado = chamado,
                    Categorias = _context.Categorias.OrderBy(c => c.Nome).ToList()
                };
                return View(vm);
            }

            var existente = _context.Chamados.Find(chamado.Id);
            if (existente == null) return NotFound();

            existente.Titulo = chamado.Titulo;
            existente.Descricao = chamado.Descricao;
            existente.Prioridade = chamado.Prioridade;
            existente.Status = chamado.Status;
            existente.CategoriaId = chamado.CategoriaId;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Chamado/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return NotFound();

            var chamado = _context.Chamados
                .Include(c => c.Categoria)
                .FirstOrDefault(c => c.Id == id.Value);

            if (chamado == null) return NotFound();

            return View(chamado);
        }

        // POST: /Chamado/DeleteConfirmed
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var existente = _context.Chamados.Find(id);
            if (existente == null) return NotFound();

            _context.Chamados.Remove(existente);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}