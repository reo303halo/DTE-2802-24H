using StudentMVC.Data;
using StudentMVC.Migrations;
using StudentMVC.Models.Entities;

namespace StudentMVC.Models;

public class StudentRepository : IStudentRepository
{
    private static List<Student> Students { get; }

    static StudentRepository()
    {
        Students = new List<Student>
        {
            new Student
            {
                StudentId = "rol000", Firstname = "Roy Espen", Lastname = "Olsen",
                DegreeId = 2, Degree = new Degree { DegreeId = 2, Name = "Master"}
            }
        };
    }
    
    public IEnumerable<Student> GetAll()
    {
        return Students;
    }
    
    public void Save(Student student)
    {
        // Add Student to database
        // Save changes
    }
}