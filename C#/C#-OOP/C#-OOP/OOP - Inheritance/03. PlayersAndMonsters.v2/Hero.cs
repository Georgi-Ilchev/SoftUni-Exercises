using System;
using System.Collections.Generic;
using System.Text;

namespace _03._PlayersAndMonsters.v2
{
    public class Hero
    {
        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public string Username { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: { this.GetType().Name} Username: {this.Username} Level: { this.Level}";
        }
    }
}
