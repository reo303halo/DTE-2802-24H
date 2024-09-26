using Microsoft.AspNetCore.Mvc;
using ProductInventory.Models;
using ProductInventory.Models.Entities;
using ProductInventory.Models.ViewModel;

namespace ProductInventory.Controllers;


public class ProductController : Controller
{
    private IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }
    public ActionResult Index()
    {
        var products = _repository.GetAll();
        return View(products);
    }
    
    // Get : Create
    public ActionResult Create()
    {
        var product = _repository.GetProductEditViewModel();
        return View(product);
    }
    
    // Post : Create
    [HttpPost]
    public ActionResult Create([Bind("Name,Description,Price,ManufacturerId,CategoryId")] ProductEditViewModel product)
    {
        try
        {
            if (!ModelState.IsValid) return View();
            var p = new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ManufacturerId = product.ManufacturerId,
                CategoryId = product.CategoryId
            };

            _repository.Save(p);
            TempData["message"] = $"{product.Name} has been created!";
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
    
    // Get : Edit
    public ActionResult Edit(int id)
    {
        var product = _repository.GetProductEditViewModel(id);
        return View(product);
    }

    // Post : Edit
    [HttpPost]
    public ActionResult Edit(int id, [Bind("ProductId,Name,Description,Price,ManufacturerId,CategoryId")] ProductEditViewModel product)
    {
        if (!ModelState.IsValid) return View(product);
        try
        {
            var p = new Product
            {
                ProductId = id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ManufacturerId = product.ManufacturerId,
                CategoryId = product.CategoryId
            };
            
            _repository.Save(p);
            TempData["message"] = $"{product.Name} has been updated!";
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
    
    // Get/Post: Delete
    public ActionResult Delete(int id)
    {
        try
        {
            var product = _repository.GetProductEditViewModel(id);

            _repository.Delete(product.ProductId);
            TempData["message"] = $"{product.Name} has been deleted!";
        }
        catch
        {
            TempData["message"] = "No product deleted!";
        }
        return RedirectToAction("Index");
    }
}