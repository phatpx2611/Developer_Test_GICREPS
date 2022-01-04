using Developer_Test_GICREPS.Application.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Developer_Test_GICREPS.Infrastructure.Persistence
{
    public class GicContext : DbContext
    {

        public GicContext(DbContextOptions options) : base(options)
        {
        }

        public GicContext() : base()
        {
        }

        public virtual DbSet<Estimate> Estimates { get; set; }  
        public virtual DbSet<Actual> Actuals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estimate>().HasNoKey();
            modelBuilder.Entity<Actual>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
