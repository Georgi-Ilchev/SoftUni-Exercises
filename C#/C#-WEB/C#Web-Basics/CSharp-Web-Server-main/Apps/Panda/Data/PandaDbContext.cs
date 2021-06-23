using Microsoft.EntityFrameworkCore;
using Panda.Data.Models;

namespace Panda.Data
{
    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public PandaDbContext()
        {
        }

        public PandaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=DESKTOP-L3ARJIL\SQLEXPRESS;Database=Panda;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                        .HasOne(r => r.Recipient)
                        .WithMany(r => r.Packages)
                        .HasForeignKey(r => r.RecipientId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Receipt>()
                        .HasOne(r => r.Recipient)
                        .WithMany(r => r.Receipts)
                        .HasForeignKey(r => r.RecipientId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Receipt>()
                        .HasOne(r => r.Package);
        }
    }
}