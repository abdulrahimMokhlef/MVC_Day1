using MVC.Models;

namespace MVC.Repositories.Interfaces
{
  public interface IInstructorRepository : IGenericRepository<Instructor>
  {
    Instructor? GetInstructorWithRelations(int id);
  }
}
