using AGILEClassLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AGILEDataPortal.Repository.Services;
using AGILEDataPortal.Data;

namespace AGILEDataPortal.Repository
{
    public class StudentUploadRepo : IStudentUploadRepo
    {
        private readonly ApplicationDbContext _context;

        public StudentUploadRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.AsNoTracking().OrderBy(stu => stu.Id);
        }

        //public Task GetById(int id)
        //{
        //    return _context.Students.FirstOrDefault(p => p.Id == id);
        //}

        //public bool SaveChanges()
        //{
        //    return (_context.SaveChanges() >= 0);
        //}
    }
}
