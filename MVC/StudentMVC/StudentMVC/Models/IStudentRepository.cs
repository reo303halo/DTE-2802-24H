using StudentMVC.Models.Entities;

namespace StudentMVC.Models;

public interface IStudentRepository
{
    IEnumerable<Student> GetAll();

    void Save(Student student);
}