namespace ProductInventory.Models.Entities;

public class Manufacturer
{
    public int ManufacturerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Address { get; set; }
    public List<Product> Products { get; set; }
}