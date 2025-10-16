using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Context;
using MVC.Models;


namespace MVC.Controllers
{
    public class InstructorController : Controller
    {
        private readonly SchoolContext sb = new SchoolContext();

        public IActionResult getAll()
        {
            var instructors = sb.Instructors.ToList();
            return View(instructors);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.departments = sb.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            if (instructor.Name != null)
            {
                sb.Instructors.Add(instructor);
                sb.SaveChanges();
                return RedirectToAction("getAll");
            }
            ViewBag.departments = sb.Departments.ToList();
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var instructor = sb.Instructors.FirstOrDefault(i => i.Id == id);
            if (instructor == null) { return NotFound(); }

            ViewBag.departments = sb.Departments.ToList();
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            if (instructor.Name != null)
            {
                sb.Instructors.Update(instructor);
                sb.SaveChanges();
                return RedirectToAction("getAll");
            }
            ViewBag.departments = sb.Departments.ToList();
            return View(instructor);
        }
    }
}
