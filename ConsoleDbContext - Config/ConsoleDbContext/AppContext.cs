using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Config;


namespace ConsoleDbContext
{
    public class AppContext : DbContext
    {
        public AppContext() : base("nservicebus") { }
        public DbSet<UnicastBusConfigDB> unicastBusConfigs { get; set; }
        public DbSet<MessageEndpointMappingDB> messageEndpointMappings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageEndpointMappingDB>().HasRequired<UnicastBusConfigDB>(s => s.unicastBusConfigDB)
                .WithMany(s => s.messageMaps).HasForeignKey(s => s.UnicastBusConfigDBId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
