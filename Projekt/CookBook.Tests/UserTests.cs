using System.ComponentModel.DataAnnotations;
using CookBook.Models;
using Xunit;
using CookBook.Controllers;
using CookBook.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Tests;

public class UserTests
{
    [Fact]
    public void User_Validation_ShouldFail_WhenPasswordIsTooShort()
    {
        var user = new User
        {
            UserName = "test",
            Password = "123",
            Name = "Test",
            Surname = "Test",
            Birthday = new DateOnly(1997, 12, 03),
            Email = "test@test.pl",
            ConfirmEmail = "test@test.pl"
        };

        var validationContext = new ValidationContext(user);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

        Assert.False(isValid);
        
        var passwordError = validationResults.FirstOrDefault(r => r.MemberNames.Contains("Password"));
        Assert.NotNull(passwordError);
    }

    
}