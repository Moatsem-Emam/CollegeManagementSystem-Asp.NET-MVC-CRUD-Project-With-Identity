using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace College_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to provide your Name")]
        [DisplayName("Name")]
        [MinLength(2, ErrorMessage = "Name must be greater than 2 characters")]
        [MaxLength(20, ErrorMessage = "Name must be greater than 2 characters")]
        public string Full_Name { get; set; }
        [Required]
        [DisplayName("Gender")]
        public char Sex { get; set; }
        [Required(ErrorMessage = "You have to provide your Age")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "You have to provide your Contact")]
        [DisplayName("Contact")]
        public string contact_add { get; set; }
        [DisplayName("image")]
        [ValidateNever]
        public string? ImageUrl { get; set; }
		[ValidateNever]
		public List<StudentCourses> studentCourses { get; set; }

	}
}
