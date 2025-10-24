using MVC.Context;
using Serilog.Context;
//using static ASP_.NET_MVC_lab.Repositories.GenericRepository;
using static System.Object;
using MVC.Repositories.Interfaces;
 

namespace MVC.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {

      private readonly SchoolContext context;

      public GenericRepository(SchoolContext _context)
      {
        context = _context;
      }

      public void Add(T entity)
      {
        context.Set<T>().Add(entity);
        context.SaveChanges();
      }

      public void Delete(int id)
      {
        var entity = GetById(id);
        if (entity != null)
        {
          context.Set<T>().Remove(entity);
          context.SaveChanges();
        }
      }

      public List<T> GetAll()
      {
        return context.Set<T>().ToList();
      }

      public T? GetById(int id)
      {
        return context.Set<T>().Find(id);
      }

      public void Update(T entity)
      {
        context.Set<T>().Update(entity);
        context.SaveChanges();
      }
    }
  }

