using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Concrete
{
    public class SPELContext : DbContext
    {
        public SPELContext () : base("SPELContext")
        {

        }

        public DbSet<Sport> sporten { get; set; }
        public DbSet<Sportklasse> klasses { get; set; }
        public DbSet<Lid> Leden { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<BetalingType> BetalingTypes { get; set; }
        public DbSet<Betaling> Betalingen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            

        }
    }
}
