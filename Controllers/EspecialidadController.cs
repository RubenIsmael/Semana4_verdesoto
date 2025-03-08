using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana_3.Data;
using Semana_3.Models;
using System.Linq;

namespace Semana_3.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly Get_PostDbContext _context;

        public EspecialidadController(Get_PostDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var especialidades = from e in _context.Especialidades
                                 select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                especialidades = especialidades.Where(e => e.Nombre.Contains(searchString));
            }

            return View(especialidades.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EspecialidadModel especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Especialidades.Add(especialidad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        

        [HttpPost]
        public IActionResult Edit(EspecialidadModel especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        public IActionResult Delete(int id)
        {
            var especialidad = _context.Especialidades.Find(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var especialidad = _context.Especialidades.Find(id);
            if (especialidad != null)
            {
                _context.Especialidades.Remove(especialidad);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}