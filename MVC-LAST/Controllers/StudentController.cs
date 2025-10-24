using MVC.Context;
using MVC.Filters;

using MVC.Models;
using MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace MVC.Controllers
{
    public class StudentController : Controller
    {
    private readonly IStudentRepository repository;
    private readonly IDepartmentRepository department;


    public StudentController(IStudentRepository repository, IDepartmentRepository department)
    {
      this.repository = repository;
      this.department = department;
    }
    [ResourceFilter(30)]
    public IActionResult getAll()
        {
      var students = repository.GetAll();
      return View("GetAll", students);
       
    }

        public IActionResult getById(int id)
        {
      var student = repository.GetStudentWithRelationsbySSn(id);
      if (student == null)
      {
        return Content("No Student with this SSN");
      }

      return View("getById", student);
    }


        [HttpGet]
        public IActionResult AddStudent()
        {
      ViewBag.depts = department.GetAll();
      Student student = new Student();
      return View("AddStudent", student);
    }
        [HttpPost]
        public IActionResult AddNewStudent(Student std)
        {

      if (ModelState.IsValid)
      {
        repository.Add(std);
        return RedirectToAction("GetAll");
      }
      ViewBag.depts = department.GetAll();
      return View("AddStudent", std);
    }
             

           
        
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
      var student = repository.GetById(id);
      ViewBag.depts = department.GetAll();
      if (student != null)
      {
        return View("EditStudent", student);
      }
      return Content("Student Not Found");
    }

        [HttpPost]
        public IActionResult EditStudent(Student std)
        {
      if (ModelState.IsValid)
      {
        repository.Update(std);
        return RedirectToAction("GetAll");
      }
      ViewBag.depts = department.GetAll();
      return View("EditStudent", std);

    }
        public IActionResult Delete(int id)
        {
      repository.Delete(id);
      return RedirectToAction("GetAll");
    }











        
    }
}
