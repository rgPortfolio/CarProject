using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EngineDetail>()
                .Property(x => x.Liters)
                .HasColumnType("decimal(2,1)");

            modelBuilder.Entity<SafetyDetail>()
                .Property(x => x.Rating)
                .HasColumnType("decimal(2,1)");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<InteriorDetail> InteriorDetails { get; set; }
        public DbSet<EngineDetail> EngineDetails { get; set; }
        public DbSet<ExteriorDetail> ExteriorDetails { get; set; }
        public DbSet<SafetyDetail> SafetyDetails { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        
    }
}