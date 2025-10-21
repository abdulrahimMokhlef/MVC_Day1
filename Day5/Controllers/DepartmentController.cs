using MVC.Context;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVC.Controllers

{
    public class DepartmentController : Controller
    {
        SchoolContext dptcontext = new SchoolContext();

        public IActionResult getAll()
        {
            var departments = dptcontext.Departments.ToList();
            return View(departments);
        }
        public IActionResult getById(int id)
        {
            var departments = dptcontext.Departments.Find(id);

            return View(departments);
        }
        public IActionResult getByName(int id,string name) //department/getbyname/1?name=dept1
        {
            var departments = dptcontext.Departments.FirstOrDefault(c=>c.Name==name);

            return View(departments);
            //return Content(name);
        }
        public IActionResult AddDepartment() 
        {
            return View("AddDepartment");
        }
        [HttpPost]
        public IActionResult AddNewDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                dptcontext.Departments.Add(dept);
                dptcontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
            {
                return View("AddDepartment",dept);
            }
        }
        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var dept = dptcontext.Departments.Find(id);
            var branches = Enum.GetValues(typeof(branches));
            return View(dept);
        }
        [HttpPost]
        public IActionResult EditDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                dptcontext.Update(dept);
                dptcontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
                return View(dept);
          
        }
        public IActionResult Delete(int id)
        {
            dptcontext.Departments.Remove(dptcontext.Departments.Find(id));
            dptcontext.SaveChanges();
            return RedirectToAction("getall");
        }
    }
}
