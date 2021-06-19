namespace Git.Data
{
    using Git.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class GitDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Commit> Commits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-L3ARJIL\SQLEXPRESS;Database=Git;Integrated Security=True");
            }
        }
    }
}
