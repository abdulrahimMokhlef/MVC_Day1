using MVC.Context;
using MVC.Filters;
using MVC.Models;
using MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ASP_.NET_MVC_lab.Controllers
{
    public class InstructorController : Controller
    {
    private readonly IInstructorRepository repository;
    private readonly IDepartmentRepository department;

    public InstructorController(IInstructorRepository repository, IDepartmentRepository department)
    {
      this.repository = repository;
      this.department = department;
    }


    //[CustomAuthorizeFilter("Admin")]
    public IActionResult getAll()
        {

      var instructors = repository.GetAll();
      return View("GetAll", instructors);
    }

    public IActionResult getById(int id)
        {
      var instructor = repository.GetInstructorWithRelations(id);

      if (instructor == null)
      {
        return Content("No instructor with this Id");
      }

      return View("getById", instructor);
    }
        public IActionResult addInstructor()
        {
      ViewBag.depts = department.GetAll();
      Instructor instructor = new Instructor();
      return View("AddInstructor", instructor);
    }


        [HttpPost]
        public IActionResult addNewInstructor(Instructor ins)
        {
      if (ModelState.IsValid)
      {
        repository.Add(ins);
        return RedirectToAction("GetAll");
      }
      ViewBag.depts = department.GetAll();
      return View("AddInstructor", ins);
    }
        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
      var instructor = repository.GetById(id);
      ViewBag.depts = department.GetAll();
      if (instructor != null)
      {
        return View("EditInstructor", instructor);
      }
      return Content("Student Not Found");
    }
        [HttpPost]
        public IActionResult EditInstructor(Instructor inst)
        {
      if (ModelState.IsValid)
      {
        repository.Update(inst);
        return RedirectToAction("GetAll");
      }
      ViewBag.depts = department.GetAll();
      return View("EditInstructor", inst);

    }
        public IActionResult Delete(int id)
        {
      repository.Delete(id);
      return RedirectToAction("GetAll");
    }






    }
}
