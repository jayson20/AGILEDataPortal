using AGILEClassLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGILEDataPortal.Repository.Services
{
    public interface ITeacherUploadRepo
    {
        IEnumerable<Teacher> GetAll();
        Task CreateTeacherAsync(Teacher teacher);
        //bool SaveChanges();
    }
}
