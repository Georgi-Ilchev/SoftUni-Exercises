using System;
using System.Collections.Generic;
using System.Text;

namespace problem15___Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            Item = item;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hero: {this.Name} - {this.Level}lvl");
            sb.AppendLine($"Item:");
            sb.AppendLine($"    * Strength: {this.Item.Strength}");
            sb.AppendLine($"    * Ability: {this.Item.Ability}");
            sb.Append($"    * Intelligence: {this.Item.Intelligence}");
            return sb.ToString().TrimEnd();
        }
    }
}
