using System.ComponentModel.DataAnnotations;

namespace jwtcore.Data.Entities
{

    public class Specialization {
        [Key]
        public int SpecializationId {get; set;}

        public string MajCode {get; set;}

        public string MajDesc {get; set;}
        public string StudentUwiId {get; set;}

    }

}