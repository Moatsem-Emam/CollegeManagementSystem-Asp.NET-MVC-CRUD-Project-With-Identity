using College_Management_System.Data;
using College_Management_System.Models;
using CollegeManagementSystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace College_Management_System.Controllers
{
    public class SchedulesController : Controller
    {
        public AppDbContext _context;
        public SchedulesController(AppDbContext context)
        {
            _context = context;
        }
     
        // Schedules ---Index--- Return View
        public IActionResult GetIndexView()
        {
            return View("Index", _context.schedules.Include(s => s.Courses).ToList());
        }


        // Schedules ---Creation--- Return View
        public IActionResult GetCreateView()
        {
            ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");


            return View("Create");
        }


        // Schedules ---Edit--- Return View
        public IActionResult GetEditViews(int id)
        {
            ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");


            return View("Edit", _context.schedules.Include(s => s.Courses).FirstOrDefault(s => s.Id == id));
        }





        // Schedules ---Details--- Return View
        public IActionResult GetDetails(int id)
        {

            var Detail = _context.schedules.Include(s => s.Courses).FirstOrDefault(s => s.Id == id);
            if (Detail != null)
            {
                return View("Details", Detail);
            }
            return NotFound();
        }


        // Schedules ---Creation--- action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateS(Schedules schedules)
        {
            
            if (ModelState.IsValid)
            {
                _context.schedules.Add(schedules);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }

            ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");
           
            return View("Create", schedules);
        }


        // Schedules ---Edit--- action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditS(Schedules schedules)
        {
            
            if (ModelState.IsValid)
            {
                
                _context.schedules.Update(schedules);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }

            ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");

            return View("Create", schedules);
        }
        // Student ---Delete--- Return View
        public IActionResult GetRemoveView(int id)
        {
            ViewBag.AllCourses = new SelectList(_context.Courses.ToList(), "Id", "course_name");

            return View("Remove", _context.schedules.Include(s => s.Courses).FirstOrDefault(s => s.Id == id));
        }


        // Schedules ---Delete--- action
        [HttpPost]
        public IActionResult DeleteS(int Id)
        {
            var schedules = _context.schedules.FirstOrDefault(s => s.Id == Id);
            if (schedules != null)
            {
                
                _context.schedules.Remove(schedules);
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
