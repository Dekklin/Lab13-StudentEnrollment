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
    public class ClassesController : Controller
    {
        private StudentDB _context;

        public ClassesController(StudentDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Initial load for creating a Class
        /// </summary>
        /// <param>none</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID, Teacher, Subject")]Classes Class)
        {
            await _context.Class.AddAsync(Class);
            await _context.SaveChangesAsync();
            int id = Class.ID;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Classes Class)
        {

            _context.Class.Update(Class);
            await _context.SaveChangesAsync();
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id.HasValue)
            {
                return View(await ClassDetailViewModel.FromIDAsync(id.Value, _context));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> ViewAll()
        {
            var dta = await _context.Class.ToListAsync();
            return View(dta);
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var match = await _context.Class.FindAsync(id);
            if(match == null)
            {
                return NotFound();
            }
            _context.Class.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewAll");
        }

    }
}