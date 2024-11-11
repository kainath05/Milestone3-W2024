using HPlusSport.Security.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HPlusSport.Security.Web.Controllers;

/*Course: 		Web Programming 3
* Assessment: 	Milestone 3
* Created by: 	Kainath Ahmed - 2268774
* Date: 		<11> <November> 2024
* Class Name: 	HomeController.cs
* Description: 	Explain what the class stores and its functionality. 
* Time Task B):	Record how long did this tutorial take you to do without breaks, in hours. 
*/

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
