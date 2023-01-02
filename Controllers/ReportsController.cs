using Microsoft.AspNetCore.Mvc;

namespace AGILEDataPortal.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
