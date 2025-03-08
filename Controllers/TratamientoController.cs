using Microsoft.AspNetCore.Mvc;
using Semana_3.Data;
using Semana_3.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Semana_3.Controllers
{
    public class TratamientoController : Controller
    {
        private readonly Get_PostDbContext _context;

        public TratamientoController(Get_PostDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var tratamientos = _context.Tratamientos.Include(t => t.Paciente).Include(t => t.Enfermero).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                tratamientos = tratamientos.Where(t => t.Nombre.Contains(searchString)).ToList();
            }

            return View(tratamientos);
        }

        public IActionResult Create()
        {
            ViewBag.Pacientes = _context.Pacientes.ToList();
            ViewBag.Enfermeros = _context.Enfermeros.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TratamientoModel tratamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Tratamientos.Add(tratamiento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pacientes = _context.Pacientes.ToList();
            ViewBag.Enfermeros = _context.Enfermeros.ToList();
            return View(tratamiento);
        }

        public IActionResult Edit(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if (tratamiento == null)
            {
                return NotFound();
            }
            ViewBag.Pacientes = _context.Pacientes.ToList();
            ViewBag.Enfermeros = _context.Enfermeros.ToList();
            return View(tratamiento);
        }

        [HttpPost]
        public IActionResult Edit(TratamientoModel tratamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Update(tratamiento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pacientes = _context.Pacientes.ToList();
            ViewBag.Enfermeros = _context.Enfermeros.ToList();
            return View(tratamiento);
        }

        public IActionResult Delete(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if (tratamiento == null)
            {
                return NotFound();
            }
            return View(tratamiento);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if (tratamiento != null)
            {
                _context.Tratamientos.Remove(tratamiento);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}