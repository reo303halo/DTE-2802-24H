using System.ComponentModel.DataAnnotations;

namespace CupcakeMVC.Models.Entities;

public class Cupcake
{
    public int CupcakeId { get; set; }
    [MaxLength(32)]
    public string? Name { get; set; } = "New Cupcake";
    [MaxLength(256)]
    public string? Description { get; set; }
    
    public int SizeId { get; set; }
    public Size? Size { get; set; }
    
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}