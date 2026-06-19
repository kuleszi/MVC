using Microsoft.AspNetCore.Mvc;
using CookBook.Models;
using CookBook.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CookBook.Controllers;

public class RecipeController : Controller
{
    private readonly CookBookContext _context;

    private readonly IWebHostEnvironment _webHostEnvironment;

    public RecipeController(CookBookContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;

        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var recipes = _context.Recipes.ToList();
        return View(recipes);
    }

    [Authorize]
    public IActionResult MyRecipe()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return RedirectToAction("Login", "Account");
        }

        var currentUserId = int.Parse(userIdClaim);

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

    public IActionResult Create(Recipe recipe, IFormFile? NewPhoto)
    {
        if (ModelState.IsValid)
        {
            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"[CLAIM]: Typ = {claim.Type}, Wartość = {claim.Value}");
            }
            recipe.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (NewPhoto != null && NewPhoto.Length > 0)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    NewPhoto.CopyTo(stream);
                }

                recipe.Photo = $"images/{uniqueFileName}";
            }
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return RedirectToAction(nameof(MyRecipe));

        }
        else
        {

            ViewBag.Categories = _context.Categories.ToList();
            return View(recipe);
        }
    }

    [HttpGet]
    [Authorize]
    public IActionResult Edit(int id)
    {
        var recipe = _context.Recipes.Include(r => r.Ingredients).Include(r => r.Steps).FirstOrDefault(r => r.Id == id);

        if (recipe == null)
        {
            return View("Error");
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(recipe);
        }

    }

    [HttpPost]
    [Authorize]
    public IActionResult Edit(Recipe recipe, IFormFile? NewPhoto, int id)
    {
        if (ModelState.IsValid)
        {
            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"[CLAIM]: Typ = {claim.Type}, Wartość = {claim.Value}");
            }

            recipe.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var existingRecipe = _context.Recipes.Include(r => r.Ingredients).Include(r => r.Steps).FirstOrDefault(r => r.Id == id);
            if (existingRecipe != null)
            {

                existingRecipe.Name = recipe.Name;
                existingRecipe.Description = recipe.Description;
                existingRecipe.CookTime = recipe.CookTime;
                existingRecipe.Kcal = recipe.Kcal;
                existingRecipe.Portion = recipe.Portion;
                if (NewPhoto != null && NewPhoto.Length > 0)
                {
                    if (!string.IsNullOrEmpty(existingRecipe.Photo))
                    {
                        var oldFileName = Path.Combine(_webHostEnvironment.WebRootPath, existingRecipe.Photo);

                        if (System.IO.File.Exists(oldFileName))
                        {
                            System.IO.File.Delete(oldFileName);
                        }
                    }
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        NewPhoto.CopyTo(stream);
                    }

                    existingRecipe.Photo = $"images/{uniqueFileName}";
                }
                existingRecipe.CategoryId = recipe.CategoryId;
                existingRecipe.Source = recipe.Source;
                if (existingRecipe.Ingredients != null)
                {
                    _context.Ingredients.RemoveRange(existingRecipe.Ingredients);
                }
                existingRecipe.Ingredients = recipe.Ingredients;
                if (existingRecipe.Steps != null)
                {
                    _context.Steps.RemoveRange(existingRecipe.Steps);
                }
                existingRecipe.Steps = recipe.Steps;
                // existingRecipe.Ingredients = recipe.Ingredients;
                
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(MyRecipe));

        }
        else
        {

            ViewBag.Categories = _context.Categories.ToList();
            return View(recipe);
        }
    }

    [HttpPost]
    [Authorize]

    public IActionResult Delete(int id)
    {
        var existingRecipe = _context.Recipes.Find(id);
        if (existingRecipe != null)
        {
            if (!string.IsNullOrEmpty(existingRecipe.Photo))
            {
                var oldFileName = Path.Combine(_webHostEnvironment.WebRootPath, existingRecipe.Photo);

                if (System.IO.File.Exists(oldFileName))
                {
                    System.IO.File.Delete(oldFileName);
                }
            }
            _context.Recipes.Remove(existingRecipe);
            _context.SaveChanges();
        }
        return Json(new { success = true });
    }



    public IActionResult Details(int id)
    {
        var recipe = _context.Recipes.Include(r => r.Ingredients).Include(r => r.Steps).Include(r => r.Category).FirstOrDefault(r => r.Id == id);

        if (recipe == null)
        {
            return View("Error");
        }
        else return View(recipe);
    }

    public IActionResult Search(string SearchTerm)
    {
       var searchedRecipes = _context.Recipes.Where(r => r.Name.ToLower().Contains(SearchTerm.ToLower())).Select(r => new {r.Id, r.Name}).ToList();

       
        return Json(searchedRecipes);
    }
}