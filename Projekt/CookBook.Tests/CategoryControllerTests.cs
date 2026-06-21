using CookBook.Controllers;
using CookBook.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.Tests;

public class CategoryControllerTests
{
    [Fact]
    public void Details_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        
        var options = new DbContextOptionsBuilder<CookBookContext>()
            .UseInMemoryDatabase(databaseName: "Test_Category_Database")
            .Options;

        
        using (var context = new CookBookContext(options))
        {
            var controller = new CategoryController(context);

            
            var result = controller.Details("CategoryDoesNotExist");

            Assert.IsType<NotFoundResult>(result);
        }
    }
}