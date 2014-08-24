using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApp1
{
    public class Paymessage
    {
        public int id { get; set; }
        public Guid EventId { get; set; }
        public string error { get; set; }
        public string state { get; set; }
    }
}
