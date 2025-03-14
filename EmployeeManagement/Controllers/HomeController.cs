using Sankalp_vraj_assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Sankalp_vraj_assignment_3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Add the Create action - redirects to Employees/Create
        public IActionResult Create()
        {
            return RedirectToAction("Create", "Employees");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
