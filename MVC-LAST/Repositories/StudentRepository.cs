using MVC.Context;
using MVC.Models;
using MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;

namespace MVC
    .Repositories
{
  
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
      private readonly SchoolContext context;

      public StudentRepository(SchoolContext _context) : base(_context)
      {
        context = _context;
      }

      public Student? GetStudentWithRelationsbySSn(int ssn)
      {
        return context.Students
            .Include(s => s.department)
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .FirstOrDefault(s => s.ssn == ssn);
      }
    }
  }

