﻿using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private IList<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }
        private IList<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public int Rating
        {
            get { return CalculateTeamRating(); }
        }

        private int CalculateTeamRating()
        {
            if (this.players.Any())
            {
                return (int)Math.Round(this.players.Average(p => p.Stats));
            }
            else
            {
                return 0;
            }
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string player)
        {
            if (!this.players.Any(p => p.Name == player))
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }
            Player currentPlayer = this.players.FirstOrDefault(p => p.Name == player);
            this.players.Remove(currentPlayer);
        }

        public override string ToString()
        {
            return $"{this.name} - {this.Rating}";
        }
    }
}
