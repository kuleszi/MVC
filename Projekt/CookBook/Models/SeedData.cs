using CookBook.Data;

namespace CookBook.Models;

public class SeedData
{
    public static void Initialize(CookBookContext context)
    {
        var cook = context.Users.FirstOrDefault(u => u.UserName == "admin");

        if (cook == null)
        {
            cook = new User
            {
                Name = "Jan",
                Surname = "Kowalski",
                Email = "admin@test.pl",
                ConfirmEmail = "admin@test.pl",
                UserName = "admin",
                Password = "Admin123$",
                Birthday = new DateOnly(1997, 12, 03),
            };

            context.Users.Add(cook);
            context.SaveChanges();
        }

        var breakfest = context.Categories.FirstOrDefault(c => c.Name == "Śniadania") ?? new Category { Name = "Śniadania" };
        var lunch = context.Categories.FirstOrDefault(c => c.Name == "Obiady") ?? new Category { Name = "Obiady" };
        var dinner = context.Categories.FirstOrDefault(c => c.Name == "Kolacje") ?? new Category { Name = "Kolacje" };
        var dessert = context.Categories.FirstOrDefault(c => c.Name == "Desery") ?? new Category { Name = "Desery" };
        if (!context.Categories.Any())
        {

            context.Categories.AddRange(breakfest, lunch, dinner, dessert);

            context.SaveChanges();
        }

        var breakfestOne = new Recipe
        {
            Name = "Jajka w humusie",
            Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Asperiores explicabo dolore soluta nemo exercitationem ratione animi aliquid non officia reiciendis, consectetur accusamus, voluptatum voluptates mollitia ipsam sint tenetur provident quod.",
            CategoryId = breakfest.Id,
            User = cook,
            CookTime = 120,
            Kcal = 300,
            Portion = 2,
            Photo = "images/jajka.png",
        };
        var breakfestTwo = new Recipe
        {
            Name = "Pancakes",
            Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Asperiores explicabo dolore soluta nemo exercitationem ratione animi aliquid non officia reiciendis, consectetur accusamus, voluptatum voluptates mollitia ipsam sint tenetur provident quod.",
            CategoryId = breakfest.Id,
            User = cook,
            CookTime = 120,
            Kcal = 300,
            Portion = 2,
            Photo = "images/pancake.png"
        };
        var lunchOne = new Recipe
        {
            Name = "Placki z kalafiora",
            Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Asperiores explicabo dolore soluta nemo exercitationem ratione animi aliquid non officia reiciendis, consectetur accusamus, voluptatum voluptates mollitia ipsam sint tenetur provident quod.",
            CategoryId = lunch.Id,
            User = cook,
            CookTime = 120,
            Portion = 2,
            Photo = "images/fritters.png"
        };
        var lunchTwo = new Recipe
        {
            Name = "Pieczony łosoś",
            Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Asperiores explicabo dolore soluta nemo exercitationem ratione animi aliquid non officia reiciendis, consectetur accusamus, voluptatum voluptates mollitia ipsam sint tenetur provident quod.",
            CategoryId = lunch.Id,
            User = cook,
            CookTime = 120,
            Portion = 2,
            Photo = "images/salmon.png"
        };
        var dinnerOne = new Recipe
        {
            Name = "Pieczona dynia z fetą",
            Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Asperiores explicabo dolore soluta nemo exercitationem ratione animi aliquid non officia reiciendis, consectetur accusamus, voluptatum voluptates mollitia ipsam sint tenetur provident quod.",
            CategoryId = dinner.Id,
            User = cook,
            CookTime = 120,
            Portion = 2,
            Photo = "images/pumpkins.png"
        };
        var dinnerTwo = new Recipe
        {
            Name = "Sałatka Cesar",
            Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Asperiores explicabo dolore soluta nemo exercitationem ratione animi aliquid non officia reiciendis, consectetur accusamus, voluptatum voluptates mollitia ipsam sint tenetur provident quod.",
            CategoryId = dinner.Id,
            User = cook,
            CookTime = 120,
            Portion = 2,
            Photo = "images/salad.png"
        };
        var dessertOne = new Recipe
        {
            Name = "Crumbl cookies",
            Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Asperiores explicabo dolore soluta nemo exercitationem ratione animi aliquid non officia reiciendis, consectetur accusamus, voluptatum voluptates mollitia ipsam sint tenetur provident quod.",
            CategoryId = dessert.Id,
            User = cook,
            CookTime = 120,
            Portion = 2,
            Photo = "images/crmbl-cookies.png"
        };
        var dessertTwo = new Recipe
        {
            Name = "Red Velvet",
            Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Asperiores explicabo dolore soluta nemo exercitationem ratione animi aliquid non officia reiciendis, consectetur accusamus, voluptatum voluptates mollitia ipsam sint tenetur provident quod.",
            CategoryId = dessert.Id,
            User = cook,
            CookTime = 120,
            Portion = 2,
            Photo = "images/red-velvet.png"
        };

        context.Recipes.AddRange(breakfestOne, lunchOne, dinnerOne, dessertOne, breakfestTwo, lunchTwo, dinnerTwo, dessertTwo);
        context.SaveChanges();

        if (!context.Ingredients.Any())
        {
            context.Ingredients.AddRange(
                new Ingredient { Name = "Jajka", Amount = 2, Measurement = "sztuka", RecipeId = breakfestOne.Id },
                new Ingredient { Name = "Hummus", Amount = 100, Measurement = "g", RecipeId = breakfestOne.Id },
                new Ingredient { Name = "Oliwa", Amount = 1, Measurement = "łyżka", RecipeId = breakfestOne.Id },
                new Ingredient { Name = "Mleko", Amount = 2, Measurement = "l", RecipeId = breakfestTwo.Id },
                new Ingredient { Name = "Mąka", Amount = 500, Measurement = "g", RecipeId = breakfestTwo.Id },
                new Ingredient { Name = "Jajko", Amount = 2, Measurement = "sztuka", RecipeId = breakfestTwo.Id },
                new Ingredient { Name = "Kalafior", Amount = 1, Measurement = "sztuka", RecipeId = lunchOne.Id },
                new Ingredient { Name = "Mąka", Amount = 500, Measurement = "g", RecipeId = lunchOne.Id },
                new Ingredient { Name = "Marchewka", Amount = 3, Measurement = "sztuka", RecipeId = lunchOne.Id },
                new Ingredient { Name = "Łosoś", Amount = 2, Measurement = "sztuka", RecipeId = lunchTwo.Id },
                new Ingredient { Name = "Brokuł", Amount = 1, Measurement = "sztuka", RecipeId = lunchTwo.Id },
                new Ingredient { Name = "Kalafior", Amount = 0.3, Measurement = "sztuka", RecipeId = lunchTwo.Id },
                new Ingredient { Name = "Dynia", Amount = 1, Measurement = "sztuka", RecipeId = dinnerOne.Id },
                new Ingredient { Name = "Ser feta", Amount = 400, Measurement = "g", RecipeId = dinnerOne.Id },
                new Ingredient { Name = "Oliwa", Amount = 1, Measurement = "łyżka", RecipeId = dinnerOne.Id },
                new Ingredient { Name = "Opakowanie sałaty", Amount = 1, Measurement = "sztuka", RecipeId = dinnerTwo.Id },
                new Ingredient { Name = "Kurczak", Amount = 500, Measurement = "g", RecipeId = dinnerTwo.Id },
                new Ingredient { Name = "Oliwa", Amount = 1, Measurement = "łyżka", RecipeId = dinnerTwo.Id },
                new Ingredient { Name = "Tablicka czekolady", Amount = 2, Measurement = "sztuka", RecipeId = dessertOne.Id },
                new Ingredient { Name = "Mąka", Amount = 500, Measurement = "g", RecipeId = dessert.Id },
                new Ingredient { Name = "Mleko", Amount = 1, Measurement = "l", RecipeId = dessertOne.Id },
                new Ingredient { Name = "Jajka", Amount = 5, Measurement = "sztuka", RecipeId = dessertTwo.Id },
                new Ingredient { Name = "Mąka", Amount = 700, Measurement = "g", RecipeId = dessertTwo.Id },
                new Ingredient { Name = "Mleko", Amount = 1.5, Measurement = "l", RecipeId = dessertTwo.Id }
     );

            context.SaveChanges();
        }

        if (!context.Steps.Any())
        {
            context.Steps.AddRange(
                new Step { StepNumber = 1, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = breakfestOne.Id },
                new Step { StepNumber = 2, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = breakfestOne.Id },
                new Step { StepNumber = 1, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = breakfestTwo.Id },
                new Step { StepNumber = 2, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = breakfestTwo.Id },
                new Step { StepNumber = 3, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = breakfestTwo.Id },
                new Step { StepNumber = 1, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = lunchOne.Id },
                new Step { StepNumber = 2, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = lunchOne.Id },
                new Step { StepNumber = 3, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = lunchOne.Id },
                new Step { StepNumber = 1, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = lunchTwo.Id },
                new Step { StepNumber = 2, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = lunchTwo.Id },
                new Step { StepNumber = 1, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dinnerOne.Id },
                new Step { StepNumber = 2, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dinnerOne.Id },
                new Step { StepNumber = 1, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dinnerTwo.Id },
                new Step { StepNumber = 2, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dinnerTwo.Id },
                new Step { StepNumber = 1, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dessertOne.Id },
                new Step { StepNumber = 2, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dessertOne.Id },
                new Step { StepNumber = 1, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dessertTwo.Id },
                new Step { StepNumber = 2, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dessertTwo.Id },
                new Step { StepNumber = 3, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dessertTwo.Id },
                new Step { StepNumber = 4, StepDescription = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quis eligendi rerum dolor ex provident veritatis alias temporibus doloribus quas, praesentium architecto consequuntur consectetur? Harum suscipit ut, alias modi accusamus provident?", RecipeId = dessertTwo.Id }
                );
            context.SaveChanges();
        }
        context.SaveChanges();
    }
}