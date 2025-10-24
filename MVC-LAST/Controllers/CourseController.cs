using MVC.Context;
using MVC.Filters;
using MVC.Models;
using MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace MVC.Controllers
{
    public class CourseController : Controller
    {
    private readonly ICourseRepository repository;
    public CourseController(ICourseRepository repository)
    {
      this.repository = repository;
    }
 

    //[CustomAuthorizeFilter("User")]
        public IActionResult getAll()
        {
      var courses = repository.GetAll();
      return View("GetAll", courses);
    }
        public IActionResult getById(int Id)
        {
      var course = repository.GetCourseWithRelations(Id);
      if (course == null)
      {
        return Content("Department not found.");
      }
      return View("getById", course);

    }

        [HttpGet]
        public IActionResult AddCourse( )
        {
      Course course = new Course();
      return View("AddCourse", course);
    }
        [HttpPost]
        public IActionResult AddCourse(Course crs)
        {
      if (ModelState.IsValid)
      {
        repository.Add(crs);
        return RedirectToAction("getAll");
      }
      return View("AddCourse", crs);
    }
        [HttpGet]
        public IActionResult EditCourse(int Id)
        {
      var course = repository.GetById(Id);
      if (course != null)
      {
        return View("EditCourse", course);
      }
      return Content("Department Not Found");
    }
        [HttpPost]
        public IActionResult EditCourse(Course crs)
        {
      if (ModelState.IsValid)
      {
        repository.Update(crs);
        return RedirectToAction("GetAll");
      }
      return View("EditCourse", crs);

    }
        public IActionResult Delete(int id)
        {
      repository.Delete(id);
      return RedirectToAction("GetAll");
    }
    }
}
