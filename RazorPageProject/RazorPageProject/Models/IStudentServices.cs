using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageProject.Models
{
    public interface IStudentServices 
    {
        Task DeleteAsync(int id);

        Task<Student> FindAsync(int id);

        IQueryable<Student> GetAll(int? count = null, int? page = null);

        Task<Student[]> GetAllAsync(int? count = null, int? page = null);

        Task SaveAsync(Student student);
    }
}