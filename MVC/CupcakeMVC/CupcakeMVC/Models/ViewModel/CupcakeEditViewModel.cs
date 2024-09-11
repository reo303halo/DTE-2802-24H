using System.ComponentModel.DataAnnotations;
using CupcakeMVC.Models.Entities;

namespace CupcakeMVC.Models.ViewModel;

public class CupcakeEditViewModel
{
    public int CupcakeId { get; set; }

    [Required(ErrorMessage = "Name Required")]
    [StringLength(35)]
    public string Name { get; set; } = "New Cupcake";
    [Required(ErrorMessage = "Description Required")]
    [StringLength(256)]
    public string? Description { get; set; }
    
    public int SizeId { get; set; }
    public List<Size>? Sizes { get; set; }
    public int CategoryId { get; set; }
    public List<Category>? Categories { get; set; }
}