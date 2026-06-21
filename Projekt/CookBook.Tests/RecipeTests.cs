using System.ComponentModel.DataAnnotations;
using CookBook.Models;
using Xunit;

namespace CookBook.Tests;

public class RecipeTests
{
    [Fact]
    public void Recipe_Validation_ShouldFail_WhenNameIsEmpty()
    {
        var recipe = new Recipe
        {
            Name = "",
            Description = "...",
            CookTime = 30,
            Kcal = 500,
            Portion = 2
        };

        var context = new ValidationContext(recipe);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(recipe, context, results, true);

        Assert.False(isValid);
        Assert.Contains(results, r => r.MemberNames.Contains("Name"));
    }
}