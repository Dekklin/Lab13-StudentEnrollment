using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class StudentDetailViewModel
    {
        public List<Student> Students;
        public Classes Class;

        public static async Task<StudentDetailViewModel> FromIDAsync(int id, StudentDB context)
        {
            StudentDetailViewModel advm = new StudentDetailViewModel();

            advm.Class =
                await context.Class.Where(c => c.ID == id).SingleAsync();

            advm.Students =
                await context.Students.Where(s => s.Class == advm.Class)
                    .Select(s => s)
                    .ToListAsync();

            return advm;
        }
    }
}
