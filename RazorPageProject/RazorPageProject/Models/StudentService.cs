using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.Data;

namespace RazorPageProject.Models
{
    public class StudentService : IStudentServices
    {
        private StudentDbContext _context;

        public StudentService()
        {
            var options = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase("MyStudentFinder")
                .Options;
            _context = new StudentDbContext(options);
        }

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Students.Remove(new Student { ID = id });
            await _context.SaveChangesAsync();
        }

        public async Task<Student> FindAsync(int id)
        {
            var results = await _context.Students.FirstOrDefaultAsync(x => x.ID == id);
            return results;
        }

        public IQueryable<Student> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _context.Students
                    .Skip(actualCount * page.GetValueOrDefault(0))
                    .Take(actualCount);
        }

        public Task<Student[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(Student student)
        {
            var doesItExist = student.ID == default(int);

            _context.Entry(student).State = doesItExist ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
