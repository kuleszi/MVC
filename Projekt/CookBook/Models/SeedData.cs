using CookBook.Data;

namespace CookBook.Models;

public class SeedData
{
    public static void Initialize(CookBookContext context)
    {
        var breakfest = new Category{Name="Śniadanie"};
        var lunch = new Category{Name="Obiad"};
        var dinner = new Category{Name="Kolacja"};
        var dessert = new Category{Name="Deser"};

        var cook = new User { Name = "Jan", Surname = "Kowalski", Email = "jan@test.pl", ConfirmEmail="jan@test.pl", UserName = "jankowalski", Password = "123", Birthday=new DateOnly(1997, 12, 03), };

        if(!context.Categories.Any())
        {
             context.Categories.AddRange(breakfest, lunch, dinner, dessert);

             context.SaveChanges();
        }


        if(!context.Recipes.Any())
        {
             context.Recipes.AddRange(new Recipe{Name="Jajka w humusie", Description="...", Category= breakfest, User= cook, CookTime=120, Portion=2}, new Recipe{Name="Placki z kalafiora", Description="...", Category= lunch, User= cook, CookTime=120, Portion=2}, new Recipe{Name="Pieczona dynia z fetą", Description="...", Category= dinner, User= cook, CookTime=120, Portion=2}, new Recipe{Name="Crumbl cookies", Description="...", Category= dessert, User= cook, CookTime=120, Portion=2});

             context.SaveChanges();
        }
    }
}