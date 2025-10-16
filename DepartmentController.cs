using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Context;
using MVC.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;



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
        public IActionResult getByName(int id, string name)
        {
            var departments = dptcontext.Departments.FirstOrDefault(c => c.Name == name);

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
                dptcontext.Departments.Add(dept);
                dptcontext.SaveChanges();
                return RedirectToAction("getAll");
            }
            else
            {
                return View("AddDepartment");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = dptcontext.Departments.FirstOrDefault(s => s.DeptId == id);
            if (department == null)
            {
                return NotFound();
            }
            ViewBag.departments = dptcontext.Departments.ToList();
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var dept = dptcontext.Departments.FirstOrDefault(s => s.DeptId == department.DeptId);
            if (dept == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(department.Name))
            {
                dept.Name = department.Name;
                dept.Manager = department.Manager;
                dept.Location = department.Location;
                dept.Branch = department.Branch;
                dptcontext.SaveChanges();
                return RedirectToAction("getAll");
            }

            ViewBag.departments = dptcontext.Departments.ToList();
            return View("Edit", department);
        }
    }
}
