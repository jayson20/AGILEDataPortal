using AGILEClassLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGILEDataPortal.Repository.Services
{
    public interface IStudentUploadRepo
    {
        IEnumerable<Student> GetAll();

        //Task GetById(string id);

        Task CreateStudentAsync(Student student);
        //bool SaveChanges();
    }
}
