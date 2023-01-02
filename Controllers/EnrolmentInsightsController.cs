using AGILEClassLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AGILEDataPortal.Controllers
{
    //[AllowAnonymous]
    [Authorize]
    public class EnrolmentInsightsController : Controller
    {
        public IActionResult StudentEnrolment()
        {
            return View();
        }
        public IActionResult SpecialNeeds()
        {
            return View();
        }
        public IActionResult TeachersByGender()
        {
            return View();
        }
        public IActionResult ComputerTeacher()
        {
            return View();
        }
        public IActionResult TeacherStudentRatio()
        {
            return View();
        }
    }
}
