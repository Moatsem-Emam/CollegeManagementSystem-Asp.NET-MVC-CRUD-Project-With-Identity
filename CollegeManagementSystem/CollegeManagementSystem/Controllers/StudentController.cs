using College_Management_System.Data;
using College_Management_System.Models;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace College_Management_System.Controllers
{
	public class StudentController : Controller
	{
		public AppDbContext _context;
		public IWebHostEnvironment _webHostEnvironment;
		public StudentController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}


		// Student ---Index--- Return View
		public IActionResult GetIndexView()
		{
			var students = _context.students.Include(s => s.studentCourses).ThenInclude(sc => sc.course).ToList();
			return View("Index",students);
		}


		// Student ---Creation--- Return View
		public IActionResult GetCreateView()
		{
			ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");


			return View("Create");
		}
		public IActionResult GetAssignView()
		{
			ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");


			return View("AssignCourses");
		}


		// Student ---Edit--- Return View
		public IActionResult GetEditViews(int id)
		{
			ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");


			return View("Edit", _context.students.Include(s => s.studentCourses).FirstOrDefault(s => s.Id == id));
		}


		


		// Student ---Details--- Return View
		public IActionResult GetStudDetails(int id)
		{

			var Detail = _context.students.Include(s => s.studentCourses).FirstOrDefault(s => s.Id == id);
			if (Detail != null)
			{
				return View("Details", Detail);
			}
			return NotFound();
		}
		public IActionResult GetStudCourDetails(int id)
		{

			var Detail = _context.StudentCourses.Include(sc => sc.course).FirstOrDefault(sc => sc.studentId == id);
			if (Detail != null)
			{
				return View("DetailsStudCours", Detail);
			}
			return NotFound();
		}


		// Student ---Creation--- action
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateS(Student student, int selectedCourseId, IFormFile? imageFormFile)
		{
			if (imageFormFile != null)
			{
				string imgExtension = Path.GetExtension(imageFormFile.FileName);
				Guid imgGuid = Guid.NewGuid();
				string imgName = imgGuid + imgExtension;
				string imgUrl = "\\Images\\" + imgName;
				student.ImageUrl = imgUrl;

				string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

				FileStream imgStream = new FileStream(imgPath, FileMode.Create);
				imageFormFile.CopyTo(imgStream);
				imgStream.Dispose();
			}
			else
			{
				student.ImageUrl = "\\Images\\No_Image.png";
			}


			if (ModelState.IsValid)
			{
				//var course = _context.Courses.Find(selectedCourseId);
				//if (course != null)
				//{
				//	student.courses = new List<Courses> { course };
				//}
               
                _context.students.Add(student);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}

			ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");
			return View("Create", student);
		}


		// Student ---Edit--- action
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditS(Student student, int selectedCourseId, IFormFile? imageFormFile)
		{
			if (imageFormFile != null)
			{
				if (student.ImageUrl != "\\images\\No_Image.png")
				{
					string oldImgPath = _webHostEnvironment.WebRootPath + student.ImageUrl;

					if (System.IO.File.Exists(oldImgPath) == true)
					{
						System.IO.File.Delete(oldImgPath);
					}
				}


				string imgExtension = Path.GetExtension(imageFormFile.FileName);
				Guid imgGuid = Guid.NewGuid();
				string imgName = imgGuid + imgExtension;
				string imgUrl = "\\images\\" + imgName;
				student.ImageUrl = imgUrl;

				string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

				FileStream imgStream = new FileStream(imgPath, FileMode.Create);
				imageFormFile.CopyTo(imgStream);
				imgStream.Dispose();
			}
			else
			{
				student.ImageUrl = "\\images\\No_Image.png";
			}



			if (ModelState.IsValid)
			{
				//var course = _context.Courses.Find(selectedCourseId);
				//if (course != null)
				//{
				//	student.studentCourses = new List<StudentCourses> { course };
				//}

				_context.students.Update(student);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}

			ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");
			return View("Create", student);
		}
		//Student ---Delete--- Return View
		//public IActionResult GetRemoveView(int id)
		//{ 
		//	return View("Remove", _context.students.FirstOrDefault(s => s.Id == id));
		//}


		// Student ---Delete--- action
		[HttpPost]
		public IActionResult DeleteS(int Id)
		{
			var student = _context.students.FirstOrDefault(s => s.Id == Id);
			if (student != null)
			{
				if (student.ImageUrl != "\\images\\No_Image.png")
				{
					string imgPath = _webHostEnvironment.WebRootPath + student.ImageUrl;
					if (System.IO.File.Exists(imgPath))
					{
						System.IO.File.Delete(imgPath);
					}
				}
				_context.students.Remove(student);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
			else
			{
				return NotFound();
			}
		}
		public IActionResult AssignCourses(int id)
		{
			var student = _context.students
				.Include(s => s.studentCourses)
				.ThenInclude(sc => sc.course)
				.FirstOrDefault(s => s.Id == id);

			if (student == null)
			{
				return NotFound();
			}

			var availableCourses = _context.Courses.ToList();

			var model = new StudentAssignCoursesViewModel
			{
				StudentId = student.Id,
				AvailableCourses = new SelectList(availableCourses, "CourseId", "Title"),
				SelectedCourseIds = student.studentCourses.Select(sc => sc.courseId).ToList()
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult AssignCourses(StudentAssignCoursesViewModel model)
		{
			var student = _context.students.Include(s => s.studentCourses).FirstOrDefault(s=>s.Id == model.StudentId);

			if (student == null)
			{
				return NotFound();
			}

			// Update the student's courses based on the selected course IDs
			student.studentCourses = model.SelectedCourseIds.Select(courseId => new StudentCourses { studentId = student.Id, courseId = courseId }).ToList();

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
