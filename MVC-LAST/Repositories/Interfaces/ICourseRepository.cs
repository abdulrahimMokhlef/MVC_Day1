using MVC.Models;

namespace MVC.Repositories.Interfaces
{
  public interface ICourseRepository : IGenericRepository<Course>
  {
    Course? GetCourseWithRelations(int id);
  }
}
