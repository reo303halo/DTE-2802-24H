using System.Security.Principal;
using CupcakeMVC.Data;
using CupcakeMVC.Models.Entities;
using CupcakeMVC.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CupcakeMVC.Models;

public class CupcakeRepository : ICupcakeRepository
{
    private readonly CupcakeDbContext _db;
    private CupcakeEditViewModel _viewModel;
    private readonly UserManager<IdentityUser> _manager;

    public CupcakeRepository(CupcakeDbContext db, UserManager<IdentityUser> userManager)
    {
        _db = db;
        _manager = userManager;
    }

    public IEnumerable<Cupcake> GetAll()
    {
        try
        {
            var cupcakes = _db.Cupcake
                .Include(c => c.Size)
                .Include(c => c.Category)
                .Include(c => c.Owner)
                .ToList();
            return cupcakes;
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            
            return new List<Cupcake>();
        }
    }

    public void Save(Cupcake cupcake, IPrincipal principal)
    {
        var user = _manager.FindByNameAsync(principal.Identity.Name).Result;

        cupcake.Owner = user;
        _db.Cupcake.Add(cupcake);
        _db.SaveChanges();
    }

    public CupcakeEditViewModel GetCupcakeEditViewModel()
    {
        _viewModel = new CupcakeEditViewModel
        {
            Sizes = _db.Size.ToList(),
            Categories = _db.Category.ToList()
        };
        return _viewModel;
    }
}