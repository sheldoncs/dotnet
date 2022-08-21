using System.ComponentModel.DataAnnotations;

namespace jwtcore.Data.Entities.Dtos
{

    public class AuthenticateReadDto {
        [Required]
        public string Username {get; set;}
        
    }
    
}