using MVC.Repositories.Interfaces;
using MVC.Context;
using MVC.Filters;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVC.Controllers
{
    public class DepartmentController : Controller
    {
    private readonly IDepartmentRepository repository;

    public DepartmentController(IDepartmentRepository repository)
    {
      this.repository = repository;
    }

    //[CacheResultFilter(duration: 60)]
    public IActionResult getAll()
        {

      var departments = repository.GetAll();

      return View("GetAll", departments);

          }
        public IActionResult getById(int id)
        {
      var department = repository.GetDepartmentWithRelations(id);
      if (department == null)
      {
        return Content("Department not found.");
      }
      return View("GetById", department);
    }
        public IActionResult getByName(int id,string name)  
        {
      var department = repository.GetDepartmentByName(name);
      if (department == null)
      {
        return Content("Department not found.");
      }
      return View("GetById", department);
    }
        public IActionResult AddDepartment() 
        {
      Department department = new Department();
      return View("AddDepartment", department);
    }
        [HttpPost]
        public IActionResult AddNewDepartment(Department dept)
        {

      if (ModelState.IsValid)
      {
        repository.Add(dept);
        return RedirectToAction("getAll");
      }
      return View("AddDepartment", dept);
    }

    public IActionResult AddV2()
    {
      Department department = new Department();

      return View("AddV2", department);

    }


    [HttpPost]
    [AllowedLocationActionFilter]

    public IActionResult AddNewV2(Department dept)
    {
      if (ModelState.IsValid)
      {
        repository.Add(dept);
        return RedirectToAction("getAll");
      }
      return View("AddV2", dept);
    }
    [HttpGet]
        public IActionResult EditDepartment(int id)
        {
      var department = repository.GetById(id);
      if (department != null)
      {
        return View("Edit", department);
      }
      return Content("Department Not Found");
    }
        [HttpPost]
        public IActionResult EditDepartment(Department dept)
        {
      if (ModelState.IsValid)
      {
        repository.Update(dept);
        return RedirectToAction("GetAll");
      }
      return View("Edit", dept);
    
          
        }
        public IActionResult Delete(int id)
        {
      repository.Delete(id);
      return RedirectToAction("GetAll");
    }
    }
}
