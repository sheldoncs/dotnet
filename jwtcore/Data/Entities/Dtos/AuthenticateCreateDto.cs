using System.ComponentModel.DataAnnotations;

namespace jwtcore.Data.Entities.Dtos {

    public class AuthenticateCreateDto {
        [Required]
        public string Username {get; set;}

        [Required]
        public string Password {get; set;}
    }
    
}