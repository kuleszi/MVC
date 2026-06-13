using CookBook.Data;

namespace CookBook.Models;

public class SeedData
{
    public static void Initialize(CookBookContext context)
    {
        if(!context.Categories.Any())
        {
             context.Categories.AddRange(new Category{Name="Śniadanie"}, new Category{Name="Obiad"}, new Category{Name="Kolacja"}, new Category{Name="Deser"});

             context.SaveChanges();
        }

        if(!context.Recipes.Any())
        {
             context.Recipes.AddRange(new Recipe{Name="Jajka w humusie"}, new Recipe{Name="Placki z kalafiora"}, new Recipe{Name="Pieczona dynia z fetą"}, new Recipe{Name="Crumbl cookies"});

             context.SaveChanges();
        }
    }
}