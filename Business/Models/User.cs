﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class User : Model
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Log> Logs { get; set; }
    }
}
