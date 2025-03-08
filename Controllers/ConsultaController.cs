using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana_3.Data;
using Semana_3.Models;
using System.Linq;

namespace Semana_3.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly Get_PostDbContext _context;

        public ConsultaController(Get_PostDbContext context)
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
    }
}