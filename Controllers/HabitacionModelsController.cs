using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Semana4.Data;
using Semana4.Models;

namespace Semana4.Controllers
{
    public class HabitacionModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabitacionModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HabitacionModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habitaciones.ToListAsync());
        }

        // GET: HabitacionModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacionModel = await _context.Habitaciones
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacionModel == null)
            {
                return NotFound();
            }

            return View(habitacionModel);
        }

        // GET: HabitacionModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HabitacionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabitacion,Numero,Tipo")] HabitacionModel habitacionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitacionModel);
        }

        // GET: HabitacionModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacionModel = await _context.Habitaciones.FindAsync(id);
            if (habitacionModel == null)
            {
                return NotFound();
            }
            return View(habitacionModel);
        }

        // POST: HabitacionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHabitacion,Numero,Tipo")] HabitacionModel habitacionModel)
        {
            if (id != habitacionModel.IdHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionModelExists(habitacionModel.IdHabitacion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(habitacionModel);
        }

        // GET: HabitacionModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacionModel = await _context.Habitaciones
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacionModel == null)
            {
                return NotFound();
            }

            return View(habitacionModel);
        }

        // POST: HabitacionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacionModel = await _context.Habitaciones.FindAsync(id);
            if (habitacionModel != null)
            {
                _context.Habitaciones.Remove(habitacionModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionModelExists(int id)
        {
            return _context.Habitaciones.Any(e => e.IdHabitacion == id);
        }
    }
}
