
using AGILEClassLibrary;
using System.Threading.Tasks;
using System;
using AGILEDataPortal.Data;
using AGILEDataPortal.Repository.Services;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AGILEDataPortal.Repository
{
    public class SchoolUploadRepo : ISchoolUploadRepo
    {
        private readonly ApplicationDbContext _context;

        public SchoolUploadRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateSchoolAsync(School school)
        {
            if (school == null)
            {
                throw new ArgumentNullException(nameof(school));
            }
            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<School> GetAll()
        {
            return _context.Schools.AsNoTracking().OrderBy(stu => stu.Id);
        }
        
    }
}
