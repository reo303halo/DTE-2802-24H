namespace CupcakeMVC.Models.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = "Regular";
    public List<Cupcake>? Cupcakes { get; set; }
}