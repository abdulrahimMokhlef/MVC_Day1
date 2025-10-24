using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Filters
{
   public class CacheResultFilterAttribute : Attribute, IResultFilter
  {
    private readonly int _duration;  

     public CacheResultFilterAttribute(int duration)
    {
      _duration = duration;
    }

     public void OnResultExecuting(ResultExecutingContext context)
    {
       if (context.Result is ViewResult)
      {
         context.HttpContext.Response.Headers["Cache-Control"] =
            $"public, max-age={_duration}";

         context.HttpContext.Response.Headers["Vary"] = "Accept-Encoding";
      }
    }

      public void OnResultExecuted(ResultExecutedContext context)
    {
     }
  }
}
