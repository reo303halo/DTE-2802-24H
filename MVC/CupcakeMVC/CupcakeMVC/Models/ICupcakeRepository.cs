using CupcakeMVC.Models.Entities;
using CupcakeMVC.Models.ViewModel;

namespace CupcakeMVC.Models;

public interface ICupcakeRepository
{
    IEnumerable<Cupcake> GetAll();

    void Save(Cupcake cupcake);

    CupcakeEditViewModel GetCupcakeEditViewModel();
    
    
}