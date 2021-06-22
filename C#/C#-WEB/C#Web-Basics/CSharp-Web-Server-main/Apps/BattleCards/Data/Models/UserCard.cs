namespace BattleCards.Data.Models
{
    public class UserCard
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
