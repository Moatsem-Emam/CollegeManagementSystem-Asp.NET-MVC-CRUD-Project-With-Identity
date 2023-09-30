using College_Management_System.Data;
using College_Management_System.Models;
using CollegeManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace College_Management_System.Controllers
{
	public class CoursesController : Controller
	{
		public AppDbContext _context;
		public CoursesController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult GetIndexView()
		{
			var courses = _context.Courses.Include(c => c.studentCourses).ThenInclude(sc => sc.student).ToList();
			return View("Index",courses);
		}

		public IActionResult GetCreateView()
		{
			ViewBag.AllSchedules = new SelectList(_context.schedules.ToList(), "Id", "Day");

			ViewBag.AllStudents = new SelectList(_context.students.ToList(), "Id", "Full_Name");
			return View("Create");
		}

		public IActionResult GetRemoveView(int id)
		{
			ViewBag.AllSchedules = new SelectList(_context.schedules.ToList(), "Id", "Day");

			ViewBag.AllStudents = new SelectList(_context.students.ToList(), "Id", "Full_Name");
			return View("Remove", _context.Courses.FirstOrDefault(c => c.Id == id));
		}
		//public IActionResult GetDetails(int id)
		//{

		//	var Detail = _context.Courses.FirstOrDefault(c => c.Id == id);
		//	if (Detail != null)
		//	{
		//		return View("Details", Detail);
		//	}
		//	return NotFound();
		//}
        public IActionResult GetEditViews(int id)
        {
			ViewBag.AllSchedules = new SelectList(_context.schedules.ToList(), "Id", "Day");
			ViewBag.AllStudents = new SelectList(_context.students.ToList(), "Id", "Full_Name");
			return View("Edit", _context.Courses.Include(c => c.studentCourses).FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
		public IActionResult CreateC(Courses courses)
		{
			
			if (ModelState.IsValid)
			{
				_context.Courses.Add(courses);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
			ViewBag.AllSchedules = new SelectList(_context.schedules.ToList(), "Id", "Day");
			ViewBag.AllStudents = new SelectList(_context.students.ToList(), "Id", "Full_Name");
			return View("Create", courses);
		}
        public IActionResult EditC(Courses courses)
        {

            if (ModelState.IsValid)
            {
				_context.Courses.Update(courses);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            ViewBag.AllSchedules = new SelectList(_context.schedules.ToList(), "Id", "Day");
			ViewBag.AllStudents = new SelectList(_context.students.ToList(), "Id", "Full_Name");
			return View("Edit", courses);
        }
        [HttpPost]
		public IActionResult DeleteC(int Id)
		{
			var course = _context.Courses.FirstOrDefault(c => c.Id == Id);
			if (course != null)
			{
				_context.Courses.Remove(course);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
			else
			{
				return NotFound();
			}
		}
	}
}