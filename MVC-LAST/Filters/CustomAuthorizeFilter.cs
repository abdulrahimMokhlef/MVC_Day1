using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace MVC.Filters
{
   public class CustomAuthorizeFilter : Attribute, IAuthorizationFilter
  {
    private readonly string _requiredRole;

     public CustomAuthorizeFilter(string requiredRole)
    {
      _requiredRole = requiredRole;
    }

     public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
      {
         context.Result = new UnauthorizedResult();
        return;
      }

       if (!context.HttpContext.User.IsInRole(_requiredRole))
      {
         context.Result = new ForbidResult();
        return;
      }

     }
  }
}
