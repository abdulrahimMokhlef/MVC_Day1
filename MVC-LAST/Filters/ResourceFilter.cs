using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Filters
{
   public class ResourceFilter : Attribute, IResourceFilter
  {
    private readonly int _duration;
     private static readonly Dictionary<string, (IActionResult Result, DateTime CachedAt)> _cache = new Dictionary<string, (IActionResult, DateTime)>();

    public ResourceFilter(int durationSeconds)
    {
      _duration = durationSeconds;
    }

     public void OnResourceExecuting(ResourceExecutingContext context)
    {
      var cacheKey = context.HttpContext.Request.Path.ToString();

       if (_cache.ContainsKey(cacheKey))
      {
        var cacheEntry = _cache[cacheKey];

         if (cacheEntry.CachedAt.AddSeconds(_duration) > DateTime.Now)
        {
           context.Result = cacheEntry.Result;
          Console.WriteLine($"*** Resource Filter: Serving from Cache for {cacheKey}");
          return;  
        }
        else
        {
           _cache.Remove(cacheKey);
        }
      }
     }

     public void OnResourceExecuted(ResourceExecutedContext context)
    {
      var cacheKey = context.HttpContext.Request.Path.ToString();

      if (context.Result is ContentResult contentResult)  
      {
         _cache[cacheKey] = (contentResult, DateTime.Now);
        Console.WriteLine($"*** Resource Filter: Caching new result for {cacheKey}");
      }
    }
  }
}
