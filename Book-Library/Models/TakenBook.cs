using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Models
{
    public class TakenBook
    {
        public DateTime WasTaken { get; set; }
        public DateTime ToReturn { get; set; }
        public string bookISBN { get; set; }
        public string Person{ get; set; }
    }
}
