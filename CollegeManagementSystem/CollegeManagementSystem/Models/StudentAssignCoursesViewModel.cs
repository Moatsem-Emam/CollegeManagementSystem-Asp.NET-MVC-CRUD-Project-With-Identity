using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeManagementSystem.Models
{
	public class StudentAssignCoursesViewModel
	{
		public int StudentId { get; set; }

		// List of available courses for selection
		public SelectList? AvailableCourses { get; set; }

		// IDs of selected courses
		public List<int>? SelectedCourseIds { get; set; }
	}
}
