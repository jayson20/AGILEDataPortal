using AGILEClassLibrary;
using System.Threading.Tasks;
using System;
using AGILEDataPortal.Data;
using AGILEDataPortal.Repository.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AGILEDataPortal.Repository
{
    public class TeacherUploadRepo : ITeacherUploadRepo
    {
        private readonly ApplicationDbContext _context;

        public TeacherUploadRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.AsNoTracking().OrderBy(stu => stu.Id);
        }

       
    }
}
