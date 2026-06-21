using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CookBook.Models;
using Microsoft.AspNetCore.Authorization;


namespace CookBook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]   
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int? statusCode = null)
    {
        var errorModel = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            StatusCode = statusCode
        };

        if(statusCode == 404) errorModel.Message = "Przykro nam! Strona, której szukasz nie istnieje. :(";
        else if(statusCode == 403) errorModel.Message = "Przykro nam! Nie masz odpowiednich uprawnień by dostać się do tej strony";
        else errorModel.Message = "Przykro nam! Wystąpił nieoczekiwany błąd po stronie serwera. Spróbuj ponownie później!";
    
        return View(errorModel);
    }
}
