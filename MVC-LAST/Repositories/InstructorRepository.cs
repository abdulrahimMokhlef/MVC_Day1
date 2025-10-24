using MVC.Context;
using MVC.Models;
using MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;

namespace MVC.Repositories
{
  public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
  {

    private readonly SchoolContext context;

    public InstructorRepository(SchoolContext _context) : base (_context)
    {
      context = _context;
    }

    public Instructor? GetInstructorWithRelations(int id)
    {
      return context.Instructors
          .Include(i => i.Department)
          .Include(i => i.InstructorCourses)
          .ThenInclude(ic => ic.Course)
          .FirstOrDefault(i => i.Id == id);
    }
  }
  }

