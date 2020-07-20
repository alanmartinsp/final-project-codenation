using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class User : Model
    {
        [Key]
        public string Hash { get; set; }
    }
}
