using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Model
{
    public class Paginator
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
        public string? Location { get; set; }
    }
}
