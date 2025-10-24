using MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class BindingController : Controller
    {
         
        public IActionResult TestPre(int id , string name , string[] color) //RouteSegment | QueryString | FormData | ReqBody | set default
        {
            return Content("Hello from TestPre");
        }
        public IActionResult TestComplex(Department dept)
        {
            return Content("Hello from TestComplex");

        }
    }
}
