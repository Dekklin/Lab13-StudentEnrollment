using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class ClassDetailViewModel
    {

        public IEnumerable<Student> Students { get; set; }
        public Classes Class { get; set; }

        public static async Task<ClassDetailViewModel> FromIDAsync(int id, StudentDB context)
        {
            ClassDetailViewModel advm = new ClassDetailViewModel();

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
