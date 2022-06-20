using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZADANIE_8_APBD.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Franek",
                    LastName = "Kowalski",
                    Email = "j@k.com",
                },
                new Doctor
                {
                    IdDoctor = 4,
                    FirstName = "Bronek",
                    LastName = "Walecki",
                    Email = "k@s.com"
                }
            };

            var patients = new List<Patient>
            {
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Franek",
                    LastName = "Kowalski"
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Bronek",
                    LastName = "Walecki"
                }
            };

            var prescriptions = new List<Prescription>
            {
                new Prescription
                {
                    Date = DateTime.Now,
                    IdPatient = 3,
                    IdDoctor = 3,

                },
                new Prescription
                {
                    Date = DateTime.Now,
                    IdPatient = 2,
                    IdDoctor = 4,
                }
            };

            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(e => e.IdDoctor);
                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Email).HasMaxLength(100).IsRequired();

                e.HasData(doctors);

                e.ToTable("Doctor");
            });

            modelBuilder.Entity<Patient>(e =>
            {
                e.HasKey(e => e.IdPatient);
                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Birthdate).IsRequired();

                e.HasData(patients);

                e.ToTable("Patient");
            });

            modelBuilder.Entity<Prescription>(e =>
            {
                e.HasKey(e => e.IdDoctor);
                e.Property(e => e.Date).IsRequired();
                e.Property(e => e.DueDate).IsRequired();

                e.HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.Patient)
               .WithMany(e => e.Prescriptions)
               .HasForeignKey(e => e.IdPatient)
               .OnDelete(DeleteBehavior.Restrict);

                e.HasData(prescriptions);

                e.ToTable("Prescription");
            });
        }
    }
}
