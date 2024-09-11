namespace CupcakeMVC.Models.Entities;

public class Size
{
    public int SizeId { get; set; }
    public string Name { get; set; } = "Medium";
    public List<Cupcake>? Cupcakes { get; set; }
}