using HPlusSport.Security.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HPlusSport.Security.Web.Controllers;

/*Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Kainath Ahmed - 2268774
* Date: 		<11> <November> 2024
* Class Name: 	HomeController.cs
* Description: 	Explain what the class stores and its functionality. 
* Time Task B):	Record how long did this tutorial take you to do without breaks, in hours. 
*/
public class AccountController : Controller
{
    private readonly ShopContext _context;

    public AccountController(ShopContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    // GET: Account/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    public async Task<ActionResult> Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user == null)
        {
            ViewData["Message"] = "User name or password invalid";
            return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        return RedirectToAction("Index", "Shop");
    }

    public ActionResult Logout()
    {
        return View();
    }

    // POST: Account/Logout
    [HttpPost, ActionName("Logout")]
    public async Task<ActionResult> LogoutPost()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
