#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hosApp.Models;

public class hospital : DbContext
{
    public hospital(DbContextOptions<hospital> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .HasOne(b => b.Case)
            .WithOne(i => i.Patient)
            .HasForeignKey<Case>(b => b.PatientRef);

        modelBuilder.Entity<Consultation>()
            .HasOne(b => b.Prescription)
            .WithOne(i => i.Consultation)
            .HasForeignKey<Prescription>(b => b.idConsul);

    }

    public DbSet<hosApp.Models.Doctor> Doctor { get; set; }

    public DbSet<hosApp.Models.Consultation> Consultation { get; set; }

    public DbSet<hosApp.Models.Patient> Patient { get; set; }

    public DbSet<hosApp.Models.Prescription> Prescription { get; set; }

    public DbSet<hosApp.Models.Case> Case { get; set; }
}
