using Microsoft.AspNetCore.Mvc;
using CookBook.Models;
using CookBook.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CookBook.Controllers;

public class RecipeController : Controller
{
    private readonly CookBookContext _context;

    public RecipeController(CookBookContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var recipes = _context.Recipes.ToList();
        return View(recipes);
    }

    [Authorize]
    public IActionResult MyRecipe()
    {
        var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var userRecipes = _context.Recipes.Where(r => r.UserId == currentUserId).ToList();

        return View(userRecipes);
    }
    [HttpGet]
    [Authorize]

    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();

        return View();
    }

    [HttpPost]
    [Authorize]

    public IActionResult Create(Recipe recipe)
    {
        if (ModelState.IsValid)
        {
            recipe.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return RedirectToAction("MyRecipe");
        }
        else {
            ViewBag.Categories = _context.Categories.ToList();
            return View(recipe);}
    }

    [HttpPost]
    [Authorize]

    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    [Authorize]

    public IActionResult Delete()
    {
        return View();
    }

    [HttpPost]
    [Authorize]

    public IActionResult Show()
    {
        return View();
    }
}