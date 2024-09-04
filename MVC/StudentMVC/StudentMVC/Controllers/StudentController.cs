using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;
using StudentMVC.Models.Entities;

namespace StudentMVC.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository _repository;

    public StudentController(IStudentRepository repository)
    {
        _repository = repository;
    }
    
    
    // GET
    public IActionResult Index()
    {
        var students = _repository.GetAll();
        
        return View(students);
    }
    
}