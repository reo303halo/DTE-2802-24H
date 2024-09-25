namespace ProductAPI.Models;

public class ProductDto // Data Transfer Objects
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}