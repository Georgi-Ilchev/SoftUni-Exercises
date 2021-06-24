using Microsoft.EntityFrameworkCore;
using Suls.Data.Models;

namespace SulsApp.Data
{
    public class SulsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-L3ARJIL\SQLEXPRESS;Database=Suls;Integrated Security=True");
            }
        }
    }
}