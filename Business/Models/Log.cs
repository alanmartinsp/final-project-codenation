using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Log : Model
    {
        public enum Type
        {
            Error,
            Warning,
            Debug
        }

        public Type Level { get; set; }
        public int Event { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Origin { get; set; }
        public string Details { get; set; }

        public virtual User User { get; set; }
    }
}
