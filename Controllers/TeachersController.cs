using AGILEClassLibrary;
using AGILEDataPortal.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AGILEDataPortal.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherUploadRepo _repository;

        public TeachersController(ITeacherUploadRepo repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public string GetTeachers()
        {
            try
            {
                var list = _repository.GetAll();
                var result = JsonConvert.SerializeObject(new { data = list });
                return result;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}
