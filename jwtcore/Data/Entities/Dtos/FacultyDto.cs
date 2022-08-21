using System.ComponentModel.DataAnnotations;

namespace jwtcore.Data.Entities.Dtos
{

    public class FacultyDto {

        [Required]
        public string CollCode {get; set;}
        public string LecturerId {get; set;}
        public string ProgramCode {get; set;}
        public string ClasCode {get; set;}

        
        


    }

}