using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookBook.Models;
using CookBook.Data;

namespace CookBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CookBookContext _context;

        public CategoryController(CookBookContext context)
        {
            _context = context;
        }

        public IActionResult Details(string name)
        {
            var categoryExists = _context.Categories.Any(c => c.Name == name);

            if (!categoryExists)
            {
                return NotFound();
            }

            ViewBag.CategoryName = name;


            var recipesInCategory = _context.Recipes
                .Include(r => r.Category)
                .Where(r => r.Category.Name == name)
                .ToList();

            return View(recipesInCategory);
        }
    }
}