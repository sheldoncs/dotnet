
using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos {
    public class NotificationDto {

       
    
    public string Message { get; set; }
   
    public string Timestamp { get; set; }
    [Required]
     public string Uuid { get; set; }

    }

}