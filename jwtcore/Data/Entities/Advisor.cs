using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jwtcore.Data.Entities {

    public class Advisor {

        [Key]
        public int AdvisorId { get; set; }
    
        [Required]
        public int StudentId {get; set;}

        [Required]
        public string StaffId {get; set;}

        [Required]
        public string Firstname {get; set;}

        [Required]
        public string Lastname {get; set;}

        
         public List<Student> Students {get; set;}
         public List<Programme> Programmes {get; set;}
       
    }
     

}