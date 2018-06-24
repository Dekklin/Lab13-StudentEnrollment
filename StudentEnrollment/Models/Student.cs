using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int ClassID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Classes Class { get; set; }
    }
}
