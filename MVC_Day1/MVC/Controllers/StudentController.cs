using Microsoft.AspNetCore.Mvc;
using MVC.Context;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        CompanyContext db = new CompanyContext();

        public IActionResult getAll()
        {
            var students = db.Students.ToList();
            return View("getAll", students);
        }

        public IActionResult getByID(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
