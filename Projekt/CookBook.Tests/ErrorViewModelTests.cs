using CookBook.Models;
using Xunit;

namespace CookBook.Tests;

public class ErrorViewModelTests
{
    [Fact] 
    public void ShowRequestId_ShouldReturnTrue_WhenRequestIdIsNotEmpty()
    {
        
        var model = new ErrorViewModel { RequestId = "12345" };

        
        bool result = model.ShowRequestId;

        
        Assert.True(result);
    }
}