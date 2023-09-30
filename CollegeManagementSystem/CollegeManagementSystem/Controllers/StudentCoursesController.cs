using College_Management_System.Data;
using College_Management_System.Models;
using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementSystem.Controllers
{
	public class StudentCoursesController : Controller
	{
		public AppDbContext _context;
		public StudentCoursesController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult GetIndexView()
		{
			ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");
			ViewBag.AllStudents = new SelectList(_context.students.ToList(), "Id", "Full_Name"); 
			return View("Index");
		}
		public IActionResult GetAssignView()
		{
			ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");
			ViewBag.AllStudents = new SelectList(_context.students.ToList(), "Id", "Full_Name");

			return View("Assign");
		}
		public IActionResult Create(int studentId, int courseId)
		{
			if (ModelState.IsValid)
			{
				// Check if the combination already exists in the StudentCourses table
				var existingAssignment = _context.StudentCourses
					.FirstOrDefault(sc => sc.studentId == studentId && sc.courseId == courseId);

				if (existingAssignment == null)
				{
					var studentCourse = new StudentCourses
					{
						studentId = studentId,
						courseId = courseId
					};

					_context.StudentCourses.Add(studentCourse);
					_context.SaveChanges();

					return RedirectToAction("GetIndexView");
				}
				else
				{
					ModelState.AddModelError("", "This student has already been assigned to this course.");
				}
			}

			ViewBag.AllStudents = new SelectList(_context.students.ToList(), "Id", "Full_Name");
			ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");
			return View("Assign");
		}

	}
}
