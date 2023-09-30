using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College_Management_System.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string course_name { get; set;}
        [DisplayName("Description")]
        public string course_desc { get; set;}
        [ForeignKey("StudentID")]
        public List<Student>? students { get; set; }

        [ValidateNever]
        public List<StudentCourses> studentCourses { get; set; }
	}
}
