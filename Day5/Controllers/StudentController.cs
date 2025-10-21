using MVC.Context;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_MVC_lab.Controllers
{
    public class StudentController : Controller
    {
        
        //}
        SchoolContext stdcontext = new SchoolContext();
        public IActionResult getAll()
        {
            var students = stdcontext.Students.ToList();
            return View(students);
        }
        public IActionResult getById(int id)
        {
            var student = stdcontext.Students.Include(m => m.StudentCourses).ThenInclude(m=>m.Course).FirstOrDefault(m=>m.ssn==id);
            
            return View(student);
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            var depts = stdcontext.Departments.ToList();
            ViewBag.depts = depts;
            return View("AddStudent");
        }
        [HttpPost]
        public IActionResult AddNewStudent(Student std)
        {
             
                if (ModelState.IsValid)
                {
                    stdcontext.Students.Add(std);
                    stdcontext.SaveChanges();
                    return RedirectToAction("getAll");
                }
                else
                {
                    var depts = stdcontext.Departments.ToList();
                    ViewBag.depts = depts;
                    return View("AddStudent", std);
                }
             

           
        }
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = stdcontext.Students.Find(id);
            var dept = stdcontext.Departments.ToList();
            ViewBag.depts = dept;
            return View(student);
        }
        [HttpPost]
        public IActionResult EditStudent(Student std)
        {
            if (ModelState.IsValid)
            {
                stdcontext.Update(std);
                stdcontext.SaveChanges();
                return RedirectToAction("getAll");

            }
            else
                return RedirectToAction("EditStudent");
           
        }
        public IActionResult Delete(int id)
        {
            //var std = stdcontext.Students.Find(id);
            stdcontext.Students.Remove(stdcontext.Students.Find(id));
            stdcontext.SaveChanges();
            return RedirectToAction("getall");
        }











        
    }
}
