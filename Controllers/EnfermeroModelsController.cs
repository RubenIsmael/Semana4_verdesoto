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
    public class EnfermeroModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnfermeroModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnfermeroModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enfermeros.Include(e => e.Especialidad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EnfermeroModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeroModel = await _context.Enfermeros
                .Include(e => e.Especialidad)
                .FirstOrDefaultAsync(m => m.IdEnfermero == id);
            if (enfermeroModel == null)
            {
                return NotFound();
            }

            return View(enfermeroModel);
        }

        // GET: EnfermeroModels/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "IdEspecialidad", "Especialidad");
            return View();
        }

        // POST: EnfermeroModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnfermero,Nombre,Telefono_Enfermero,EspecialidadId")] EnfermeroModel enfermeroModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermeroModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "IdEspecialidad", "Especialidad", enfermeroModel.EspecialidadId);
            return View(enfermeroModel);
        }

        // GET: EnfermeroModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeroModel = await _context.Enfermeros.FindAsync(id);
            if (enfermeroModel == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "IdEspecialidad", "Especialidad", enfermeroModel.EspecialidadId);
            return View(enfermeroModel);
        }

        // POST: EnfermeroModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnfermero,Nombre,Telefono_Enfermero,EspecialidadId")] EnfermeroModel enfermeroModel)
        {
            if (id != enfermeroModel.IdEnfermero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermeroModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeroModelExists(enfermeroModel.IdEnfermero))
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
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "IdEspecialidad", "Especialidad", enfermeroModel.EspecialidadId);
            return View(enfermeroModel);
        }

        // GET: EnfermeroModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermeroModel = await _context.Enfermeros
                .Include(e => e.Especialidad)
                .FirstOrDefaultAsync(m => m.IdEnfermero == id);
            if (enfermeroModel == null)
            {
                return NotFound();
            }

            return View(enfermeroModel);
        }

        // POST: EnfermeroModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfermeroModel = await _context.Enfermeros.FindAsync(id);
            if (enfermeroModel != null)
            {
                _context.Enfermeros.Remove(enfermeroModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeroModelExists(int id)
        {
            return _context.Enfermeros.Any(e => e.IdEnfermero == id);
        }
    }
}
