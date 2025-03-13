using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Semana4.Models;

namespace Semana4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
        public IActionResult Enfermero()
    {
        return View();
    }
    public IActionResult Especialidad()
    {
        return View();
    }
    public IActionResult Habitacion()
    {
        return View();
    }
    public IActionResult Paciente()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
