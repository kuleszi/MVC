namespace CookBook.Models;
public class Recipe
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public int CookTime {get; set;}
    public int Kcal {get; set;}
    public string Photo {get; set;}
    public int CategoryId {get; set;}
    public Category Category {get; set;}
    public List<Ingredient> Ingredients {get; set;}
    public List<Step> Steps {get; set;}
    public int UserId {get; set;}
    public User User {get; set;}
}
