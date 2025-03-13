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
    public class EspecialidadModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EspecialidadModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidades.ToListAsync());
        }

        // GET: EspecialidadModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadModel = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.IdEspecialidad == id);
            if (especialidadModel == null)
            {
                return NotFound();
            }

            return View(especialidadModel);
        }

        // GET: EspecialidadModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEspecialidad,Especialidad,Descripcion,Funciones")] EspecialidadModel especialidadModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidadModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidadModel);
        }

        // GET: EspecialidadModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadModel = await _context.Especialidades.FindAsync(id);
            if (especialidadModel == null)
            {
                return NotFound();
            }
            return View(especialidadModel);
        }

        // POST: EspecialidadModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,Especialidad,Descripcion,Funciones")] EspecialidadModel especialidadModel)
        {
            if (id != especialidadModel.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidadModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadModelExists(especialidadModel.IdEspecialidad))
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
            return View(especialidadModel);
        }

        // GET: EspecialidadModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadModel = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.IdEspecialidad == id);
            if (especialidadModel == null)
            {
                return NotFound();
            }

            return View(especialidadModel);
        }

        // POST: EspecialidadModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especialidadModel = await _context.Especialidades.FindAsync(id);
            if (especialidadModel != null)
            {
                _context.Especialidades.Remove(especialidadModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadModelExists(int id)
        {
            return _context.Especialidades.Any(e => e.IdEspecialidad == id);
        }
    }
}
