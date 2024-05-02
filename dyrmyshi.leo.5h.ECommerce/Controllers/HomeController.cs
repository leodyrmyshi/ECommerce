using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dyrmyshi.leo._5h.ECommerce.Models;

namespace dyrmyshi.leo._5h.ECommerce.Controllers;

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
    public IActionResult Carrello()
    {
        return View();
    }
    public IActionResult Registrazioni()
    {
        string? nomeUtente = HttpContext.Session.GetString("NomeUtente");
        if (string.IsNullOrEmpty(nomeUtente))
            return Redirect("\\home\\index");
        dbContext db = new dbContext();
        return View(db);
    }
    public IActionResult Registrato( Utente u)
    {
        dbContext db = new dbContext();
        db.Utenti.Add(u);
        db.SaveChanges();
        return View(u);
    }
    public IActionResult Signin()
    {
        ViewData["Login"] = true;
        return View();
    }
    public IActionResult Login()
    {
        ViewData["Login"] = true;
        return View();
    }
    public IActionResult Logout()
    {
    
        ViewData["Login"] = false;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
