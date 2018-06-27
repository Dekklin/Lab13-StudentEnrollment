using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.Models;

namespace StudentEnrollment.Controllers
{
    public class StudentController : Controller
    {
        private StudentDB _context;

        public StudentController(StudentDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            //Send the list of authors as a ViewDataList
            // Look at the .cshtml file for the drop down on how this is being transferred over
            ViewData["Students"] = await _context.Class.Select(c => c)
                .ToListAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID, Name, Class, ClassID")]Student stud)
        {
            //Get a single book
            stud.Class = await _context.Class.Where(c => c.ID == stud.ClassID).SingleAsync();

            _context.Students.Add(stud);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id.HasValue)
            {
                return View(await StudentDetailViewModel.FromIDAsync(id.Value, _context));
            }
            else
            {
                return RedirectToAction("Index");
            }
            //if (id.HasValue)
            //{
            //    //Get all the details of a book, inlcuding the author deets
            //    return View(await _context.Students.Where(s => s.ClassID == id)
            //        .Include(s => s.Class)
            //        .SingleAsync());
            //}
            //return View();

        }
        public async Task<IActionResult> ViewAll(string courseName, string searchString)
        {
            ViewData["Courses"] = await _context.Class.Select(c => c).ToListAsync();
            // Use LINQ to get list of students.
            IQueryable<string> classQuery = from c in _context.Students
                                             orderby c.Name
                                             select c.Name;

            var students = from m in _context.Students
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(courseName))
            {
                students = students.Where(x => x.Class.ToString().ToLower() == courseName.ToLower());
            }

            var student = new List<StudentEnrollment.Models.Student>();

            //student.Class = new SelectList(await classQuery.Distinct().ToListAsync());
            student = await students.ToListAsync();

            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {

            ViewData["Classes"] = await _context.Class.Select(c => c).ToListAsync();
            var student = await _context.Students.Where(s => s.ID == id)
                                                 .SingleAsync();
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            //var student1 = new List<StudentEnrollment.Models.Student>();
            //student.Class = new SelectList(await classQuery.Distinct().ToListAsync());
            //student1 = await student.ToListAsync();


            return View(student);
        }



        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);


            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewAll");
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
