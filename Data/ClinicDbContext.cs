using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ClinicManagementSystem.Data
{
    public class ClinicDbContext : IdentityDbContext<ApplicationUser>
    {

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
