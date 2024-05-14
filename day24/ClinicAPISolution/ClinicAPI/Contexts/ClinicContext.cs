using ClinicAPI.models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Contexts
{
    public class ClinicContext:DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { id = 101, name = "Ramu", speciality="brain", experience=5 },
                new Doctor{ id = 102, name = "Somu", speciality="hand", experience=2}
                );
        }
    }
}
