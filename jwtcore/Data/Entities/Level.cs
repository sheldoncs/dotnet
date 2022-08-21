using System.ComponentModel.DataAnnotations;

namespace jwtcore.Data.Entities
{
    public class Level {

         [Key]
        public int LevelId {get; set;}
        [Required]
        public string LevelCode {get; set;}
        [Required]
        public string LevelDescription {get; set;}

    }

}