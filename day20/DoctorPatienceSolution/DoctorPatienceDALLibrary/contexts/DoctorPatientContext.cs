using Microsoft.EntityFrameworkCore;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPatientDALLibrary.contexts
{
    public class DoctorPatientContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DB66JX3\\DEMOINSTANCE;Integrated Security=true;Initial Catalog=dbDoctorPatient;");
        }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Appointment> appointments { get; set; }
    }
}
