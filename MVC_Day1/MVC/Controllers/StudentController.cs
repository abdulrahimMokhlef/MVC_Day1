using MVC.Context;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;

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
            if (std.name != null)
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
    }
}