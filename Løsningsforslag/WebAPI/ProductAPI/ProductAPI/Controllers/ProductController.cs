using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers;

[Route("/api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<List<Product>> GetAll() => await _service.GetAll();

    [HttpGet("{id:int}")]
    public IActionResult Get([FromRoute] int id)
    {
        var product = _service.Get(id);
        if (product == null)
            return NotFound($"No product with the id {id}.");

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto product)
    {
        var newProduct = new Product
        {
            Name = product.Name,
            Price = product.Price
        };

        await _service.Save(newProduct);
        return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Product product)
    {
        if (id != product.Id)
            return BadRequest("Id from Route does not match product id.");

        var existingProduct = _service.Get(id);

        if (existingProduct is null)
            return NotFound($"No product with the id {id}.");

        var newProduct = new Product
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

        await _service.Save(newProduct);
        return Ok("Product successfully updated.");
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var product = _service.Get(id);
        if (product == null)
            return NotFound($"No product with the id {id}.");

        _service.Delete(id);
        return Ok("Product successfully deleted.");
    }
}