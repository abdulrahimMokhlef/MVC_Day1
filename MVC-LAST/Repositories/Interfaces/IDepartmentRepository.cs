using MVC.Models;

namespace MVC.Repositories.Interfaces
{
  public interface IDepartmentRepository : IGenericRepository<Department>
  {
    Department? GetDepartmentWithRelations(int id);

    Department? GetDepartmentByName(string Name);
  }
}
