using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Business.Models.Log;

namespace Api.Filters
{
    public class LogFilter
    {
        public int? Enviroment { get; set; }
        public string OrderBy { get; set; }
        public string Field { get; set; }
        public string FieldDescription { get; set; }
    }
}
