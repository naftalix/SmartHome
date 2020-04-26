using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// This class contains all the database tables of the devices
    /// </summary>
    public class AContext : DbContext
    {
        public AContext()
        {
            Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;;Initial Catalog=DAL.AContext;Integrated Security=True;MultipleActiveResultSets=True";
        }
        public DbSet<EDoor> EDoors { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<AC> Aces { get; set; }
        public DbSet<EHeater> EHeaters { get; set; }
        public DbSet<EShutter> EShutters { get; set; }
        public DbSet<Lamp> Lamps { get; set; }
        public DbSet<TV> TVs { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
