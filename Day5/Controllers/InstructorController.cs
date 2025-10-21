using MVC.Context;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ASP_.NET_MVC_lab.Controllers
{
    public class InstructorController : Controller
    {
        SchoolContext scontext = new SchoolContext();
        public IActionResult getAll()
        {
            //throw new Exception("An error from student controller");

            var instructors = scontext.Instructors.ToList();
            return View(instructors);
        }
        public IActionResult getById(int id)
        {
            var inst = scontext.Instructors.Find(id);
            return View(inst);
        }
        public IActionResult addInstructor()
        {
            var dept = scontext.Departments.ToList();
            ViewBag.depts = dept;
            return View("AddInstructor");
        }
        [HttpPost]
        public IActionResult addNewInstructor(Instructor ins)
        {
            if (ModelState.IsValid)
            {
                scontext.Instructors.Add(ins);
                scontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
            {
                var dept = scontext.Departments.ToList();
                ViewBag.depts = dept;
                return View("addInstructor",ins);
            }
        }
        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            var instruct = scontext.Instructors.Find(id);
            var dept = scontext.Departments.ToList();
            ViewBag.depts = dept;
            return View(instruct);
        }
        [HttpPost]
        public IActionResult EditInstructor(Instructor inst)
        {
            if (ModelState.IsValid)
            {
                scontext.Update(inst);
                scontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
                return View(inst);
          
        }
        public IActionResult Delete(int id)
        {
                scontext.Instructors.Remove(scontext.Instructors.Find(id));
                scontext.SaveChanges();
                return RedirectToAction("getall");
        }






    }
}
