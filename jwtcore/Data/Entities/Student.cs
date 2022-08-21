using System.ComponentModel.DataAnnotations;

namespace jwtcore.Data.Entities
{

    public class Student {

        [Key]
        public int StudentId {get; set;}
        [Required]
        public string StudentUwiId {get; set;}
   
        [Required]
        public string Firstname {get; set;}
    
        [Required]
        public string Lastname {get; set;}

        public Programme Programme {get; set;}
    } 
}