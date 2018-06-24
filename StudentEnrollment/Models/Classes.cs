using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Classes
    {

        public int ID { get; set; }
        [Required]
        public string Subject { get; set; }
        public List<Student> Students { get; set; }

    }
}
