using MVC.Context;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CourseController : Controller
    {
        SchoolContext scontext = new SchoolContext();
        public IActionResult getAll()
        {
            var courses = scontext.Courses.ToList();
            return View(courses);
        }
        public IActionResult getById(int Id)
        {
            return View(scontext.Courses.Find(Id));
        }
        [HttpGet]
        public IActionResult AddCourse(int Id)
        {
            return View("AddCourse");
        }
        [HttpPost]
        public IActionResult AddCourse(Course crs)
        {
            if (ModelState.IsValid)
            {
                scontext.Courses.Add(crs);
                scontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
                return View(crs);
        }
        [HttpGet]
        public IActionResult EditCourse(int Id)
        {
            var crs = scontext.Courses.Find(Id);
            return View(crs);
        }
        [HttpPost]
        public IActionResult EditCourse(Course crs)
        {
            if (ModelState.IsValid)
            {
                scontext.Update(crs);
                scontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
                return View(crs); 
    
        }
        public IActionResult Delete(int id)
        {
            scontext.Courses.Remove(scontext.Courses.Find(id));
            scontext.SaveChanges();
            return RedirectToAction("getall");
        }
    }
}
