using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace MVC.Filters
{
   public class AllowedLocationActionFilter : Attribute, IActionFilter
  {
    private readonly string[] _allowedLocations = new[] { "USA", "EG" };

    public void OnActionExecuting(ActionExecutingContext context)
    {
       if (context.ActionArguments.TryGetValue("dept", out var model) && model != null)
      {
 
         var propertyInfo = model.GetType().GetProperty("location");

        if (propertyInfo != null)
        {
          var locationValue = propertyInfo.GetValue(model) as string;

           if (string.IsNullOrEmpty(locationValue) ||
              !_allowedLocations.Contains(locationValue, StringComparer.OrdinalIgnoreCase))
          {
             context.Result = new BadRequestObjectResult(
                $"location '{locationValue}' Not Allowed Only: USA, Egypt.");

            return;
          }
        }
       }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
  }
}
