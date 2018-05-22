using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Admin
{
    public class AdminDashModel : PageModel
    {
        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Student student { get; set; }

        private readonly IStudentServices studentServices;

        public AdminDashModel(IStudentServices ss)
        {
            studentServices = ss;
        }

        public async Task OnGet()
        {
            student = await studentServices.FindAsync(ID.GetValueOrDefault()) ?? new Student();
        }

        public async Task<IActionResult> OnPost()
        {
            Student newStudent = await studentServices.FindAsync(ID.GetValueOrDefault()) ?? new Student();
            newStudent.FirstName = student.FirstName;
            newStudent.LastName = student.LastName;
            newStudent.Course = student.Course;
            newStudent.Email = student.Email;
            newStudent.GPA = student.GPA;

            await studentServices.SaveAsync(newStudent);

            return RedirectToPage("/Details", new { id = newStudent.ID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await studentServices.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}