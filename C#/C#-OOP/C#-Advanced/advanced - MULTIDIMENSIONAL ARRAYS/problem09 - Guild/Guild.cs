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
            //1
            if (this.Count < this.Capacity)
            {
                roster.Add(player);
            }
            //2
            //if (roster.Count < this.Capacity && !roster.Any(x => x.Name == player.Name))
            //{
            //    this.roster.Add(player);
            //}
        }

        public bool RemovePlayer(string name)
        {
            //1
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

            //2
            //if (roster.Any(x => x.Name == name))
            //{
            //    Player myTempPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
            //    roster.Remove(myTempPlayer);
            //    return true;
            //}
            //return false;
        }

        public void PromotePlayer(string name)
        {
            //1
            var playerToPromote = roster.FirstOrDefault(p => p.Name == name);
            if (playerToPromote != null && playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }

            //2
            //if (roster.Any(x => x.Name == name))
            //{
            //    Player myPromotedPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
            //    myPromotedPlayer.Rank = "Member";
            //}
        }
        public void DemotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                Player myDemotedPlayer = roster.Where(x => x.Name == name).FirstOrDefault();
                myDemotedPlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classPlayer)
        {
            //1
            var players = roster.Where(p => p.Class == classPlayer).ToArray();
            foreach (var player in players)
            {
                roster.Remove(player);
            }
            return players;

            //2
            //List<Player> myListTemp = new List<Player>();
            //foreach (var player in this.roster)
            //{
            //    if (player.Class == classPlayer)
            //    {
            //        myListTemp.Add(player);
            //    }
            //}
            //Player[] myArrayToReturn = myListTemp.ToArray();

            //this.roster = this.roster.Where(x => x.Class != classPlayer).ToList();

            //return myArrayToReturn;
        }

        public string Report()
        {
            //1
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Players in the guild: {this.Name}")
               .Append(string.Join(Environment.NewLine, roster));
            return sb.ToString().TrimEnd();

            //2
            //StringBuilder myString = new StringBuilder();
            //myString.AppendLine($"Players in the guild: {this.Name}");
            //foreach (var player in this.roster)
            //{
            //    myString.AppendLine($"Player {player.Name}: {player.Class}");
            //    myString.AppendLine($"Rank: {player.Rank}");
            //    myString.AppendLine($"Description: {player.Description}");
            //}
            //return myString.ToString().TrimEnd();
        }
    }
}
