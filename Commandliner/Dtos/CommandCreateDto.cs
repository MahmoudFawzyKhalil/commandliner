using System.ComponentModel.DataAnnotations;

namespace Commandliner.Dtos
{
    public class CommandCreateDto
    {
        // These [Required] data annotations makes it so when the client doesn't provide
        // any of these properties they get a 400 Bad Request error, instead of a 500 Internal Server Error
        // and a whole pile of exceptions
        [Required]
        public string HowTo { get; set; }
        
        [Required]
        public string Line { get; set; }
        
        [Required]
        public string Platform { get; set; }
    }
}
