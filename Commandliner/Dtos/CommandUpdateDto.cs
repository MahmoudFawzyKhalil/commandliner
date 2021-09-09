using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandliner.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
