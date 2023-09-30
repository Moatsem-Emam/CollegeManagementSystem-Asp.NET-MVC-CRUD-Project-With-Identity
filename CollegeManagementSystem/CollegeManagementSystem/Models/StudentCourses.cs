using College_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
	public class StudentCourses
	{
		[Key]
		public int Id { get; set; }
		public int courseId { get; set; }
		public Courses? course { get; set; }
		public int studentId { get; set; }
		public Student? student { get; set; }
	}
}
