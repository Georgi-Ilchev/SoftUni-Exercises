using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-L3ARJIL\SQLEXPRESS;Database=Hospital;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Patient
            modelBuilder.Entity<Patient>(x =>
            {
                x.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                x.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                x.Property(p => p.Address)
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode(true);

                x.Property(p => p.Email)
                .HasMaxLength(80)
                .IsRequired(true)
                .IsUnicode(false);

                x.Property(p => p.HasInsurance)
                .IsRequired(true);
            });

            //Visitation
            modelBuilder.Entity<Visitation>(x =>
            {
                x.Property(p => p.Date)
                .IsRequired(true);

                x.Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode(true)
                .IsRequired(true);
            });

            //Diagnose
            modelBuilder.Entity<Diagnose>(x =>
            {
                x.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                x.Property(x => x.Comments)
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode(true);
            });

            //Medicament
            modelBuilder.Entity<Medicament>(x =>
            {
                x.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);
            });

            //PatientMedicament 
            modelBuilder.Entity<PatientMedicament>(x =>
            {
                x.HasKey(p => new { p.PatientId, p.MedicamentId });
            });

            //Doctor
            modelBuilder.Entity<Doctor>(x =>
            {
                x.Property(x => x.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

                x.Property(x => x.Specialty)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
