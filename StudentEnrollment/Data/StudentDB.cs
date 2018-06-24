using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Models;

namespace StudentEnrollment.Data
{
    public class StudentDB:DbContext
    {
        public StudentDB(DbContextOptions<StudentDB> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classes> Class { get; set; }
        
    }
}
