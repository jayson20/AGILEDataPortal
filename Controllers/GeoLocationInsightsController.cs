using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AGILEDataPortal.Controllers
{
    //[AllowAnonymous]
    [Authorize]
    public class GeoLocationInsightsController : Controller
    {
        public IActionResult SchoolByLGA()
        {
            return View();
        }
    }
}
