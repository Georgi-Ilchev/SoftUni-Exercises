namespace Andreys.Data
{
    using Andreys.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class AndreysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-L3ARJIL\SQLEXPRESS;Database=Andreys;Integrated Security=True");
            }
        }
    }
}
