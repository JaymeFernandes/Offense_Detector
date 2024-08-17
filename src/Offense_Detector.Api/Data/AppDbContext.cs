using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Offense_Detector.Data.Models.Entity;

namespace Offense_Detector.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Offense> _offenses { get; set; }

        public virtual DbSet<FalsePositive> _falsePositives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offense>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Word)
                    .HasColumnName("Offense")
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(90);
            });

            modelBuilder.Entity<FalsePositive>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Word)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(90);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}