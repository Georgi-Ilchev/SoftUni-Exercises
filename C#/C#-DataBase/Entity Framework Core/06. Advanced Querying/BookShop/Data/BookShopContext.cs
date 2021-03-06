using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
        {
        }
        public BookShopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BooksCategories { get; set; }

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
            
            modelBuilder.Entity<BookCategory>().HasKey(e => new { e.BookId, e.CategoryId });

            //modelBuilder.HasOne(e => e.Category)
            //    .WithMany(c => c.CategoryBooks)
            //    .HasForeignKey(e => e.CategoryId);

            //modelBuilder.HasOne(e => e.Book)
            //    .WithMany(c => c.BookCategories)
            //    .HasForeignKey(e => e.BookId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
