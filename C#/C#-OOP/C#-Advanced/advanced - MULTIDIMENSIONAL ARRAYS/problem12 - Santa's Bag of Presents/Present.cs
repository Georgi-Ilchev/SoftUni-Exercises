using System;
using System.Collections.Generic;
using System.Text;

namespace problem12___Santa_s_Bag_of_Presents
{
    public class Present
    {
        public Present(string name, double weight, string gender)
        {
            Name = name;
            Weight = weight;
            Gender = gender;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Present {this.Name} ({this.Weight}) for a {this.Gender}");
            return sb.ToString().TrimEnd();
        }
    }
}
