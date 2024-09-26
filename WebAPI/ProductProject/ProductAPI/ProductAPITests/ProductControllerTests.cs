using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPITests;

public class ProductControllerTests
{
    private readonly Mock<IProductService> _mock;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mock = new Mock<IProductService>();
        _controller = new ProductController(_mock.Object);
    }

    private static List<Product> GetTestProducts()
    {
        return new List<Product>
        {
            new Product { Id = 1, Name = "Hammer", Price = 76.0m},
            new Product { Id = 2, Name = "Water Bottle", Price = 30.0m},
            new Product { Id = 3, Name = "Keyboard", Price = 1299.90m},
        };
    }
    
    // GET
    [Fact]
    public async Task GetAll_ReturnsCorrectType()
    {
        // Arrange
        _mock.Setup(service => service.GetAll()).ReturnsAsync(GetTestProducts);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<List<Product>>(result);
        if (result != null) Assert.Equal(3, result.Count); // Not necessary for 100% coverage.
    }

    [Fact]
    public void Get_ReturnsProduct_WhenProductExists()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Hammer", Price = 76.0m };
        _mock.Setup(service => service.Get(1)).Returns(product);
        
        // Act
        var result = _controller.Get(1) as OkObjectResult;
        
        // Assert
        Assert.NotNull(result);
        if (result != null) Assert.Equal(product, result.Value);
    }
    
    [Fact]
    public void Get_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        _mock.Setup(service => service.Get(1)).Returns((Product)null);

        // Act
        var result = _controller.Get(1);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }
    
    //  DELETE
    [Fact]
    public void Delete_ReturnsOk_WhenProductExists()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Hammer", Price = 76.0m };
        _mock.Setup(service => service.Get(1)).Returns(product);
        _mock.Setup(service => service.Delete(1));

        // Act
        var result = _controller.Delete(1) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        if (result != null) Assert.Equal("Product successfully deleted.", result.Value);
    }

    [Fact]
    public void Delete_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        _mock.Setup(service => service.Get(1)).Returns((Product)null);

        // Act
        var result = _controller.Delete(1);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }
}