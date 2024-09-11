using CupcakeMVC.Data;
using CupcakeMVC.Models.Entities;
using CupcakeMVC.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CupcakeMVC.Models;

public class CupcakeRepository : ICupcakeRepository
{
    private readonly CupcakeDbContext _db;
    private CupcakeEditViewModel _viewModel;

    public CupcakeRepository(CupcakeDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Cupcake> GetAll()
    {
        try
        {
            var cupcakes = _db.Cupcake
                .Include(size => size.Size)
                .Include(cat => cat.Category)
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

    public void Save(Cupcake cupcake)
    {
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