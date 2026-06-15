using System.ComponentModel.DataAnnotations;

namespace CookBook.Models;
public class Recipe
{
    public int Id {get; set;}

    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string Name {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string Description {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required int CookTime {get; set;}
    public int? Kcal {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required int Portion {get; set;}
    public string? Photo {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public int CategoryId {get; set;}
    public Category Category {get; set;}
    public List<Ingredient>? Ingredients {get; set;} = new();
    public List<Step>? Steps {get; set;} = new();
    public string? Source {get; set;}
    public int UserId {get; set;}
    public User User {get; set;}
}
