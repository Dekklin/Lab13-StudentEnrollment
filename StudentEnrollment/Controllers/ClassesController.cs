using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Models;

namespace StudentEnrollment.Controllers
{
    public class ClassesController : Controller _context
    {
        public 

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Classes Class)
        {
            await _context.Classes.AddAsync(Classes Class)
            await _context.SavechangesAsync()

            return View();
        }
    }
}