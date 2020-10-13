using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using SSEPS.Repository;
using System.Diagnostics;
using System.Linq;

namespace ServerApp.Controllers {

    public class HomeController : Controller {
        private EmployeeDataContext context;

        public HomeController(EmployeeDataContext ctx) {
            context = ctx;
        }

        public IActionResult Index() {
            return View(context.Employees.First());
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, 
            NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
                ?? HttpContext.TraceIdentifier });
        }
    }
}
