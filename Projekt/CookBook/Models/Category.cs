using System.ComponentModel.DataAnnotations;

namespace CookBook.Models;
public class Category
{
    public int Id {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string Name {get; set;}
    public List<Recipe>? Recipes {get; set;} = new();
}