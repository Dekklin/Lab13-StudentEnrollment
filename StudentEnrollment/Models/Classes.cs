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
        public string Teacher { get; set; }
        public Subject Subject { get; set; }
    }
        public enum Subject
        {
            Math,
            Science,
            English,
            [Display(Name ="Computer Science")]ComputerScience,
            Art,
            History
        }
}
