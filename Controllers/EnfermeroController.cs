using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana_3.Data;
using Semana_3.Models;
using System.Linq;

namespace Semana_3.Controllers
{
    public class EnfermeroController : Controller
    {
        private readonly Get_PostDbContext _context;

        public EnfermeroController(Get_PostDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var enfermeros = _context.Enfermeros.Include(e => e.Especialidad).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                enfermeros = enfermeros.Where(e => e.Nombre.Contains(searchString) || e.Apellido.Contains(searchString)).ToList();
            }

            return View(enfermeros);
        }

        public IActionResult Create()
        {
            ViewBag.Especialidades = _context.Especialidades.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EnfermeroModel enfermero)
        {
            if (ModelState.IsValid)
            {
                _context.Enfermeros.Add(enfermero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Especialidades = _context.Especialidades.ToList();
            return View(enfermero);
        }

        public IActionResult Edit(int id)
        {
            var enfermero = _context.Enfermeros.Find(id);
            if (enfermero == null)
            {
                return NotFound();
            }
            ViewBag.Especialidades = _context.Especialidades.ToList();
            return View(enfermero);
        }

        [HttpPost]
        public IActionResult Edit(EnfermeroModel enfermero)
        {
            if (ModelState.IsValid)
            {
                _context.Update(enfermero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Especialidades = _context.Especialidades.ToList();
            return View(enfermero);
        }

        public IActionResult Delete(int id)
        {
            var enfermero = _context.Enfermeros.Find(id);
            if (enfermero == null)
            {
                return NotFound();
            }
            return View(enfermero);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var enfermero = _context.Enfermeros.Find(id);
            if (enfermero != null)
            {
                _context.Enfermeros.Remove(enfermero);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}