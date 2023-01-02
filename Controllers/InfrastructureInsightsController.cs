using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AGILEDataPortal.Controllers
{
    //[AllowAnonymous]
    [Authorize]
    public class InfrastructureInsightsController : Controller
    {
        public IActionResult Internet()
        {
            return View();
        }
        public IActionResult ComputerLab()
        {
            return View();
        }
        public IActionResult NetworkingPeripherals()
        {
            return View();
        }
        public IActionResult SourceOfElectricity()
        {
            return View();
        }
        public IActionResult Security()
        {
            return View();
        }
        public IActionResult SchoolWithPrinter()
        {
            return View();
        }
        public IActionResult SchoolsWithProjector()
        {
            return View();
        }
    }
}
