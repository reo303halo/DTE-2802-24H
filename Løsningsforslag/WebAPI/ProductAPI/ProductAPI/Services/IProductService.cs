using ProductAPI.Models;

namespace ProductAPI.Services;

public interface IProductService
{
    Task<List<Product>> GetAll();
    Product? Get(int id);
    Task Save(Product product);
    Task Delete(int id);
}