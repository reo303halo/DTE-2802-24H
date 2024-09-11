using CupcakeMVC.Models;
using CupcakeMVC.Models.Entities;
using CupcakeMVC.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeMVC.Controllers;

public class CupcakeController : Controller
{
    private ICupcakeRepository _repository;

    public CupcakeController(ICupcakeRepository repository)
    {
        _repository = repository;
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    // GET
    public ActionResult Index()
    {
        var cupcakes = _repository.GetAll();
        return View(cupcakes);
    }
    
    // Create: GET
    [Authorize]
    public ActionResult Create()
    {
        var cupcake = _repository.GetCupcakeEditViewModel();
        return View(cupcake);
    }
    
    // Create: POST
    [Authorize]
    [HttpPost]
    public ActionResult Create([Bind("Name,Description,SizeId,CategoryId")] CupcakeEditViewModel cupcake)
    {
        try
        {
            if (!ModelState.IsValid) return View();

            var c = new Cupcake
            {
                CupcakeId = cupcake.CupcakeId,
                Name = cupcake.Name,
                Description = cupcake.Description,
                SizeId = cupcake.SizeId,
                CategoryId = cupcake.CategoryId
            };
            
            _repository.Save(c);
            TempData["message"] = $"{c.Name} has been created!";
            return RedirectToAction("Index");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            TempData["message"] = "Obs something went wrong!";
            return RedirectToAction("Index");
        }
    }
    
    
}