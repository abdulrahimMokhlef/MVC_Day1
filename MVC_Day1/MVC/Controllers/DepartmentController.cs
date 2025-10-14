using MVC.Context;
using MVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace MVC.Controllers
{
    public class DepartmentController : Controller
    {
        SchoolContext dptcontext = new SchoolContext();

        public IActionResult getAll()
        {
            var departments = dptcontext.departments.ToList();
            return View(departments);
        }
        public IActionResult getById(int id)
        {
            var departments = dptcontext.departments.Find(id);

            return View(departments);
        }
        public IActionResult getByName(int id, string name)
        {
            var departments = dptcontext.departments.FirstOrDefault(c => c.Name == name);

            return View(departments);
        }
        public IActionResult AddDepartment()
        {
            return View("AddDepartment");
        }
        public IActionResult AddNewDepartment(Department dept)
        {
            if (dept.Name != null)
            {
                dptcontext.departments.Add(dept);
                dptcontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
            {
                return View("AddDepartment");
            }
        }
    }
}

