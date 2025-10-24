using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MVC.Filters
{
    public class LoggingFilterattribute : ActionFilterAttribute
    {
        Stopwatch stopwatch = new();
        override public void OnActionExecuting(ActionExecutingContext context)
        {
           Stopwatch.StartNew();
          //  context.ActionArguments["dept"]
            Console.WriteLine($"Action Method Execution started => {context.ActionDescriptor.DisplayName}");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            Console.WriteLine($"Action Method Execution finished => {context.ActionDescriptor.DisplayName} , Time taken : {stopwatch.ElapsedMilliseconds} ms");
        }
     
    }
}
