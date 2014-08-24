using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApp1
{
    public class AppContext : DbContext
    {
        public DbSet<Paymessage> Paymessages { get; set; }
    }
}
