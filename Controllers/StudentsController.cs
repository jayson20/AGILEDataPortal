using AGILEDataPortal.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AGILEDataPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentUploadRepo _repository;
        

        public StudentsController(IStudentUploadRepo repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string GetStudents()
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
