using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana_3.Data;
using Semana_3.Models;
using System.Linq;

namespace Semana_3.Controllers
{
    public class PacienteController : Controller
    {
        private readonly Get_PostDbContext _context;

        public PacienteController(Get_PostDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var pacientes = _context.Pacientes.Include(p => p.Habitacion).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                pacientes = pacientes.Where(p => p.Nombre.Contains(searchString) || p.Apellido.Contains(searchString)).ToList();
            }

            return View(pacientes);
        }

        public IActionResult Create()
        {
            ViewBag.Habitaciones = _context.Habitaciones.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(PacienteModel paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Habitaciones = _context.Habitaciones.ToList();
            return View(paciente);
        }

        public IActionResult Edit(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewBag.Habitaciones = _context.Habitaciones.ToList();
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Edit(PacienteModel paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Update(paciente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Habitaciones = _context.Habitaciones.ToList();
            return View(paciente);
        }

        public IActionResult Delete(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}