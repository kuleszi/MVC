using CookBook.Data;

namespace CookBook.Models;

public class SeedData
{
    public static void Initialize(CookBookContext context)
    {
        var breakfest = new Category{Name="Śniadania"};
        var lunch = new Category{Name="Obiady"};
        var dinner = new Category{Name="Kolacje"};
        var dessert = new Category{Name="Desery"};

        var cook = new User { Name = "Jan", Surname = "Kowalski", Email = "jan@test.pl", ConfirmEmail="jan@test.pl", UserName = "jankowalski", Password = "123", Birthday=new DateOnly(1997, 12, 03), };

        if(!context.Categories.Any())
        {
             context.Categories.AddRange(breakfest, lunch, dinner, dessert);

             context.SaveChanges();
        }


        if(!context.Recipes.Any())
        {
             context.Recipes.AddRange(new Recipe{Name="Jajka w humusie", Description="...", CategoryId = breakfest.Id, User= cook, CookTime=120, Portion=2, Photo = "images/jajka.png"}, new Recipe{Name="Placki z kalafiora", Description="...", CategoryId= lunch.Id, User= cook, CookTime=120, Portion=2}, new Recipe{Name="Pieczona dynia z fetą", Description="...", CategoryId= dinner.Id, User= cook, CookTime=120, Portion=2}, new Recipe{Name="Crumbl cookies", Description="...", CategoryId= dessert.Id, User= cook, CookTime=120, Portion=2});

             context.SaveChanges();
        }
    }
}