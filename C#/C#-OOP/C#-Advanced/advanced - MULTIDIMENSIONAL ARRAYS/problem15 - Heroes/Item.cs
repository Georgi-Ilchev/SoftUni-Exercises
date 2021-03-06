using System;
using System.Collections.Generic;
using System.Text;

namespace problem15___Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            Strength = strength;
            Ability = ability;
            Intelligence = intelligence;
        }

        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public override string ToString()
        {
            //    * Strength: 23
            //    * Ability: 35
            //    * Intelligence: 48

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Item:");
            sb.AppendLine($"    * Strength: {this.Strength}");
            sb.AppendLine($"    * Ability: {this.Ability}");
            sb.Append($"    * Intelligence: {this.Intelligence}");

            return sb.ToString().TrimEnd();
        }
    }
}
