using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Net;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Authorization;
using System.Security.Authentication.ExtendedProtection;
using CookBook.Models;
using CookBook.Data;
using SQLitePCL;

namespace CookBook.Controllers
{
    [Authorize]
    public class AccountController : Controller
{
    private readonly CookBookContext _context;

    public AccountController(CookBookContext context)
        {
            _context = context;
        }

   
    [AllowAnonymous]
    [HttpGet]
public IActionResult Login()
    {
        return View();
    }

[AllowAnonymous]
[HttpPost]
public async Task<IActionResult> Login(string username, string password, string? returnUrl)
    {
         var userInDb = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
         
        if(userInDb != null)
            {
                var claims = new List<Claim> {new Claim(ClaimTypes.Name, username)};
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if(!string.IsNullOrEmpty(returnUrl)) return LocalRedirect(returnUrl);
                return RedirectToAction("Index", "Home");
            } 
            
        else
            {
                ModelState.AddModelError(string.Empty, "Uwaga! Nieprawidłowy login lub hasło.");
                return View();
            }   
    }

    

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult AccessDenied(string? returnUrl) {
        ViewData["DeniedUrl"] = returnUrl;
        return View();
        } 

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
       _context.Users.Add(user);
       await _context.SaveChangesAsync();
       return RedirectToAction("Login");
    }
}

}