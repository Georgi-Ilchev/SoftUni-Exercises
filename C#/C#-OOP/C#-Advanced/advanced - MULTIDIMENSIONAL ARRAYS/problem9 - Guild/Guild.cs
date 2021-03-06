using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return this.roster.Count; }
        }

        public void AddPlayer(Player player)
        {
            if (this.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {

            var currPlayer = roster.FindAll(p => p.Name == name);
            if (currPlayer.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var player in currPlayer)
                {
                    roster.Remove(player);

                }

                return true;
            }

        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = roster.FirstOrDefault(p => p.Name == name);
            if (playerToPromote != null && playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var playerToDemote = roster.FirstOrDefault(p => p.Name == name);
            if (playerToDemote != null && playerToDemote.Rank != "Trail")
            {
                playerToDemote.Rank = "Trail";
            }
        }

        public Player[] KickPlayersByClass(string classPlayer)
        {

            var players = roster.Where(p => p.Class == classPlayer).ToArray();
            foreach (var player in players)
            {
                roster.Remove(player);
            }
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Players in the guild: {this.Name}")
               .Append(string.Join(Environment.NewLine, roster));
            return sb.ToString().TrimEnd();
        }
    }
}
