using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana_3.Data;

public class ReporteController : Controller
{
    private readonly Get_PostDbContext _context;

    public ReporteController(Get_PostDbContext context)
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
}