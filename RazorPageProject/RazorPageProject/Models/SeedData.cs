using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageProject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentDbContext(serviceProvider.GetRequiredService<DbContextOptions<StudentDbContext>>()))
            {
                //Check if data alread exists
                if (context.Students.Any())
                {
                    return; //No need to seed
                }
                //Create and add students
                context.Students.AddRange(
                    new Student { FirstName = "Test", LastName = "One", Course = Courses.Math, Email = "one@test.com", GPA = 3.5 },
                    new Student { FirstName = "Test", LastName = "Two", Course = Courses.English, Email = "two@test.com", GPA = 3.5 },
                    new Student { FirstName = "Test", LastName = "Three", Course = Courses.CompSci, Email = "three@test.com", GPA = 3.5 },
                    new Student { FirstName = "Test", LastName = "Four", Course = Courses.Physics, Email = "four@test.com", GPA = 3.5 },
                    new Student { FirstName = "Test", LastName = "Five", Course = Courses.Math, Email = "five@test.com", GPA = 3.5 }
                    );
                //Update database
                context.SaveChanges();
            }
        }
    }
}
