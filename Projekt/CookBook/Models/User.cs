using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Models;
public class User
{
    public int Id {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string UserName {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Hasło musi mieć conajmniej 8 znaków")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*()_+{\}[\]:;<>,.?/~`|-]).*$", ErrorMessage ="Hasło musi zawierać conajmniej jedną cyfrę i jeden symbol specjalny")]
    public required string Password {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string Name {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required string Surname {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    public required DateOnly? Birthday {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    [EmailAddress(ErrorMessage ="Niepoprawny format adresu e-mail")]
    public required string Email {get; set;}
    [Required(ErrorMessage = "To pole nie może być puste")]
    [Compare("Email", ErrorMessage ="Adresy e-mail muszą być takie same")]
    public required string ConfirmEmail {get; set;}
    [Required]
    public bool IsAdmin {get; set;} = false;
    public List<Recipe>? MyRecipes {get; set;} = new();

    
}