using System.ComponentModel.DataAnnotations;
using ProductInventory.Models.Entities;

namespace ProductInventory.Models.ViewModel;

public class ProductEditViewModel
{
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Product Name Required")]
    public string Name { get; set; }
    [StringLength(40)]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Price has to be numeric")]
    public decimal? Price { get; set; }
    public int ManufacturerId { get; set; }
    public List<Manufacturer>? Manufacturers { get; set; }
    public int CategoryId { get; set; }
    public List<Category>? Categories { get; set; }
}