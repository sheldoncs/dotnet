using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jwtcore.Data.Entities
{

    public class Programme {

       [Key]
        public int ProgramId {get; set;}

        [Required]
        public string ProgramCode {get; set;}
        [Required]
        public string ProgramDescription {get; set;}
        [Required]
        public string StudentUwiId {get; set;}

        public Faculty faculty { get; set; }
        public List<Specialization> Specializations {get; set;}
        public List<Level> Levels {get; set;}

    }
}