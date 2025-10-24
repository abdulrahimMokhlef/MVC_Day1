using MVC.Context;
using MVC.Models;
using MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;

namespace MVC.Repositories
{
  public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
  {
    private readonly SchoolContext context;

    public DepartmentRepository(SchoolContext _context) : base(_context)
    {
      context = _context;
    }

    public Department? GetDepartmentByName(string name)
    {
      return context.Departments
          .Include(d => d.Students)
          .Include(d => d.Instructors)
          .FirstOrDefault(d => d.Name == name);
    }

    public Department? GetDepartmentWithRelations(int id)
    {
      return context.Departments
          .Include(d => d.Students)
          .Include(d => d.Instructors)
          .FirstOrDefault(d => d.deptid == id);
    }
  }
}
