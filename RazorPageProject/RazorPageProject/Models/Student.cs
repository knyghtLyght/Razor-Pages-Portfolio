using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageProject.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Course")]
        public Courses Course { get; set; }

        [Display(Name = " GPA")]
        public double GPA { get; set; }
    }

    public enum Courses {Math, English, Physics, CompSci }
}
