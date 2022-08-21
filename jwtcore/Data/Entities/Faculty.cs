using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jwtcore.Data.Entities
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]
        public string FacultyCode { get; set; }
        [Required]
        public string FacultyDescription { get; set; }
       
    }
}
