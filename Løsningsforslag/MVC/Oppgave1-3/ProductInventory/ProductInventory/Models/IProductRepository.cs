using ProductInventory.Models.Entities;
using ProductInventory.Models.ViewModel;

namespace ProductInventory.Models;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();

    void Save(Product product);

    void Delete(int id);

    ProductEditViewModel GetProductEditViewModel();
    
    ProductEditViewModel GetProductEditViewModel(int id);
}