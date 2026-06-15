using System.ComponentModel.DataAnnotations;

namespace CookBook.Models;

public class Ingredient
{
    public int Id {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string Name {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required double Amount {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string Measurment {get; set;}
    public required int RecipeId {get; set;}
    public Recipe Recipe {get; set;}
}