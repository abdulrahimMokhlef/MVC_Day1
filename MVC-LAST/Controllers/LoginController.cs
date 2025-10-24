using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC.Controllers
{
  public class LoginController : Controller
  {
    [HttpGet]
    public async Task<IActionResult> LoginAsAdmin()
    {
      var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "AdminUser"),
            new Claim(ClaimTypes.Role, "Admin")  
        };

      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

       await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

      return RedirectToAction("getAll", "Instructor");
    }

     [HttpGet]
    public async Task<IActionResult> LoginAsUser()
    {
      var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "GeneralUser"),
            new Claim(ClaimTypes.Role, "User")
        };

      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

       await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

      return RedirectToAction("getAll", "Course");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return RedirectToAction("addInstructor", "Instructor");
    }
  }
}
