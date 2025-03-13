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
    public class PacienteModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacienteModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PacienteModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pacientes.Include(p => p.Habitacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PacienteModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.Pacientes
                .Include(p => p.Habitacion)
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (pacienteModel == null)
            {
                return NotFound();
            }

            return View(pacienteModel);
        }

        // GET: PacienteModels/Create
        public IActionResult Create()
        {
            ViewData["HabitacionId"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Numero");
            return View();
        }

        // POST: PacienteModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,Nombre_paciente,Apellido_Paciente,Edad,Telefono,HabitacionId")] PacienteModel pacienteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitacionId"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Numero", pacienteModel.HabitacionId);
            return View(pacienteModel);
        }

        // GET: PacienteModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.Pacientes.FindAsync(id);
            if (pacienteModel == null)
            {
                return NotFound();
            }
            ViewData["HabitacionId"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Numero", pacienteModel.HabitacionId);
            return View(pacienteModel);
        }

        // POST: PacienteModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,Nombre_paciente,Apellido_Paciente,Edad,Telefono,HabitacionId")] PacienteModel pacienteModel)
        {
            if (id != pacienteModel.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteModelExists(pacienteModel.IdPaciente))
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
            ViewData["HabitacionId"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Numero", pacienteModel.HabitacionId);
            return View(pacienteModel);
        }

        // GET: PacienteModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.Pacientes
                .Include(p => p.Habitacion)
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (pacienteModel == null)
            {
                return NotFound();
            }

            return View(pacienteModel);
        }

        // POST: PacienteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacienteModel = await _context.Pacientes.FindAsync(id);
            if (pacienteModel != null)
            {
                _context.Pacientes.Remove(pacienteModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteModelExists(int id)
        {
            return _context.Pacientes.Any(e => e.IdPaciente == id);
        }
    }
}
