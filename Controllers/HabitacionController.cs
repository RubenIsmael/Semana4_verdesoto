using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana_3.Data;
using Semana_3.Models;
using System.Linq;

namespace Semana_3.Controllers
{
    public class HabitacionController : Controller
    {
        private readonly Get_PostDbContext _context;

        public HabitacionController(Get_PostDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var habitaciones = from h in _context.Habitaciones
                               select h;

            if (!string.IsNullOrEmpty(searchString))
            {
                habitaciones = habitaciones.Where(h => h.Numero.Contains(searchString));
            }

            return View(habitaciones.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HabitacionModel habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Habitaciones.Add(habitacion);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(habitacion);
        }

        public IActionResult Edit(int id)
        {
            var habitacion = _context.Habitaciones.Find(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return View(habitacion);
        }

        [HttpPost]
        public IActionResult Edit(HabitacionModel habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Update(habitacion);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(habitacion);
        }

        public IActionResult Delete(int id)
        {
            var habitacion = _context.Habitaciones.Find(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return View(habitacion);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var habitacion = _context.Habitaciones.Find(id);
            if (habitacion != null)
            {
                _context.Habitaciones.Remove(habitacion);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}