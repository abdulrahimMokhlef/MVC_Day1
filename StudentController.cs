using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        public ContentResult test()
        {
            return Content("hello from student ctrl");
        }
         
        SchoolContext stdcontext = new SchoolContext();
        public IActionResult getAll()
        {
            var students = stdcontext.Students.ToList();
            return View(students);
        }
        public IActionResult getById(int id)
        {
            var student = stdcontext.Students.Find(id);

            return View(student);
        }
        public IActionResult AddStudent()
        {
            return View("AddStudent");
        }
        public IActionResult AddNewStudent(Student std)
        {
            if (std.Name != null)
            {
                stdcontext.Students.Add(std);
                stdcontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
            {
                return View("AddStudent");
            }
        }

    [HttpGet]
    public IActionResult Edit(int id)
    {

      var student = stdcontext.Students.FirstOrDefault(s => s.SSN == id);
      if (student == null)
      {
        return NotFound();
      }


      ViewBag.Departments = stdcontext.Departments.ToList();
      return View(student);

    }
    [HttpPost]
    public IActionResult Edit(Student student)
    {
      if (student.Name != null)
      {
        stdcontext.Students.Update(student);
        stdcontext.SaveChanges();
        return RedirectToAction("getAll");
      }
      ViewBag.Departments = stdcontext.Departments.ToList();
      return View("Edit", student);
    }

  }
}
