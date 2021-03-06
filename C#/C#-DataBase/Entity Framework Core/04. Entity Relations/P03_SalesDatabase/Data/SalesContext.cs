using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }
        public SalesContext(DbContextOptions options) : base(options)
        {
        }

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
            //Product
            modelBuilder.Entity<Product>(x =>
            {
                x.Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

                x.Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired(false)
                .IsUnicode(true)
                .HasDefaultValue("No description");
            });

            //Customer
            modelBuilder.Entity<Customer>(x =>
            {
                x.Property(x => x.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

                x.Property(x => x.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired(true);
            });

            //Store
            modelBuilder.Entity<Store>(x =>
            {
                x.Property(x => x.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);
            });

            //Sale
            modelBuilder.Entity<Sale>(x =>
            {
                x.Property(x => x.Date)
                .IsRequired(true)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

                //x.HasOne(s => s.Product)
                //.WithMany(p => p.Sales)
                //.HasForeignKey(s => s.ProductId);

                //x.HasOne(s => s.Store)
                //.WithMany(st => st.Sales)
                //.HasForeignKey(s => s.StoreId);

                //x.HasOne(s => s.Customer)
                //.WithMany(c => c.Sales)
                //.HasForeignKey(s => s.CustomerId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
