using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC.Models
{
    public class StudentModel
    {
        private static List<Student> students = new List<Student>
            {
                new Student{StudentId=1, FullName="Ali Omar", Email="ali_omar@yahoo.com", IsEnrol=true},
                 new Student{StudentId=2, FullName="Sarah Othman", Email="sarah.othman@gmail.com", IsEnrol=true},
                  new Student{StudentId=3, FullName="Saad Suliman", Email="saad.suliman2020@gmail.com", IsEnrol=true}
            };
        public static List<Student> GetStudent()
        {

            return students;
        }
    }
    public class Student
    {
        [Display(Name = "Student Id:")]
        public int StudentId { get; set; }

        [Display(Name = "Full Name:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Full name is required")]
        public string FullName { get; set; }      


        [Display(Name = "Email Address:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The Email and Confirm Email fields do not match.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Is enrolled:")]
        public bool IsEnrol { get; set; }
    }
}