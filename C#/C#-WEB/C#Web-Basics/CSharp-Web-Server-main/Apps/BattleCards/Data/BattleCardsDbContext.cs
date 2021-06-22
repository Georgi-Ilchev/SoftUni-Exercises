using BattleCards.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleCards.Data
{
    public class BattleCardsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<UserCard> UserCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-L3ARJIL\SQLEXPRESS;Database=BattleCards;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCard>()
                        .HasKey(x => new { x.UserId, x.CardId });
        }
    }
}
