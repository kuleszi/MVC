using System.ComponentModel.DataAnnotations;
namespace CookBook.Models;

public class Step
{
    public int Id {get; set;}
    public int StepNumber {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string StepDescription {get; set;}
    public int RecipeId {get; set;}
    public Recipe? Recipe {get; set;}
}