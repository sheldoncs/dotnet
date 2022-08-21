using System.ComponentModel.DataAnnotations;

namespace jwtcore.Data.Entities
{

    public class Authentication {
 
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        

    }
}