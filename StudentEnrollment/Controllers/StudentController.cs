using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            // Lok at the .cshtml file for the drop down on how this is being transferred over
            ViewData["Students"] = await _context.Students.Select(c => c)
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
                //Get all the details of a book, inlcuding the author deets
                return View(await _context.Students.Where(s => s.ClassID == id)
                    .Include(s => s.Class)
                    .SingleAsync());
            }
            return View();

        }

        public async Task<IActionResult> ViewAll()
        {
            var dta = await _context.Students.Include(s => s.Class).ToListAsync();

            return View(dta);

        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
