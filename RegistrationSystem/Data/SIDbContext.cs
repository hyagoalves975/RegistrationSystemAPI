using Microsoft.EntityFrameworkCore;
using RegistrationSystem.Models;

namespace RegistrationSystem.Data
{
    public class SIDbContext : DbContext
    {
        public DbSet<Vaccine> Vaccine { get; set; }

        public DbSet<VaccinationStation> VaccinationStation { get; set; }
        
        public SIDbContext(DbContextOptions<SIDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VaccinationStation>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Vaccine>()
                .HasIndex(v => v.Batch)
                .IsUnique();

            modelBuilder.Entity<VaccinationStation>()
                .HasMany(p => p.Vaccines)
                .WithOne(v => v.VaccinationStation)
                .HasForeignKey(v => v.VaccinationStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
