using MVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.NET_MVC_lab.Controllers
{
    [ExceptionHandleFilter]
    public class FilterTestController : Controller
    {
    //[ExceptionHandleFilter]
    //[LoggingFilterattribute]
        public IActionResult Index()
        {
            ContentResult res = new ContentResult();
            res.Content = "Hello from FilterTestController Index Action Method";

            throw new Exception("Error!!!!!");
        }
    //    [ExceptionHandleFilter]
        public IActionResult Index2()
        {
            throw new Exception("Error from Index2!!!!!");
        }
    }
}
