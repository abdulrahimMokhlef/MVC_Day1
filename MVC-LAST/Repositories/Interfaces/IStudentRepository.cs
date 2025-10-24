using MVC.Models;

namespace MVC.Repositories.Interfaces
{
  public interface IStudentRepository : IGenericRepository<Student>
  {
    Student? GetStudentWithRelationsbySSn(int ssn);
  }
}
