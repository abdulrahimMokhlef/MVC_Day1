using Microsoft.AspNetCore.Mvc;
using MVC.Context;

namespace MVC.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext db = new CompanyContext();

        public IActionResult getAll()
        {
            var depts = db.Departments.ToList();
            return View("getAll", depts);
        }

        public IActionResult Details(int id)
        {
            var dept = db.Departments.Find(id);
            return View(dept);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
