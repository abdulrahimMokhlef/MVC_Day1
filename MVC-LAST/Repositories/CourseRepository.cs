using MVC.Context;
using MVC.Models;
using MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;

namespace MVC.Repositories
{
  public class CourseRepository : GenericRepository<Course>, ICourseRepository
  {
    private readonly SchoolContext context;

    public CourseRepository(SchoolContext _context) : base(_context)
    {
      context = _context;
    }

    public Course? GetCourseWithRelations(int id)
    {
      return context.Courses
           .Include(c => c.StudentCourses)
               .ThenInclude(sc => sc.Student)
           .Include(c => c.InstructorCourses)
               .ThenInclude(ic => ic.Instructor)
           .FirstOrDefault(c => c.Id == id);
    }
  }
}
