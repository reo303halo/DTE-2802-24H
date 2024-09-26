using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using ProductInventory.Models.Entities;
using ProductInventory.Models.ViewModel;

namespace ProductInventory.Models;

public class ProductRepository: IProductRepository
{
    private ProductContext _db;
    private ProductEditViewModel _viewModel;

    public ProductRepository(ProductContext db)
    {
        _db = db;
    }

    public IEnumerable<Product> GetAll()
    {
        var products = _db.Product
            .Include(cat => cat.Category)
            .Include(man => man.Manufacturer)
            .ToList();
        return products;
    }

    public void Save(Product product)
    {
        _db.Product.Update(product);
        _db.SaveChanges();
    }

    public ProductEditViewModel GetProductEditViewModel()
    {
        _viewModel = new ProductEditViewModel
        {
            Categories = _db.Category.ToList(),
            Manufacturers = _db.Manufacturer.ToList()
        };
        return _viewModel;
    }
    
    public ProductEditViewModel GetProductEditViewModel(int id)
    {
        var product = _db.Product.Find(id);
        if (product == null) return null;

        _viewModel = new ProductEditViewModel
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ManufacturerId = product.ManufacturerId,
            CategoryId = product.CategoryId,
            Categories = _db.Category.ToList(),
            Manufacturers = _db.Manufacturer.ToList()
        };
        return _viewModel;
    }
    
    public void Delete(int id)
    {
        var product = _db.Product.Find(id);
        
        _db.Product.Remove(product);
        _db.SaveChanges();
    }
}