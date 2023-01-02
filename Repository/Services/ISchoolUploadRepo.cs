using AGILEClassLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGILEDataPortal.Repository.Services
{
    public interface ISchoolUploadRepo
    {
        IEnumerable<School> GetAll();
        Task CreateSchoolAsync(School school);

    }
}
