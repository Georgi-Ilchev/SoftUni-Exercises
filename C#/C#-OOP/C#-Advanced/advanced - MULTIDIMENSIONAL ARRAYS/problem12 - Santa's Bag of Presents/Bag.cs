using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problem12___Santa_s_Bag_of_Presents
{
    public class Bag
    {
        private List<Present> data;
        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }
        public string Color { get; set; }
        public int Capacity { get; set; }


        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Present present)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove (string name)
        {
            var currentPresent = data.FindAll(p => p.Name == name);
            if (currentPresent.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var present in currentPresent)
                {
                    data.Remove(present);
                }
                return true;
            }
        }

        public Present GetHeaviestPresent()
        {
            Present currentPresent = data.OrderByDescending(x => x.Weight).FirstOrDefault();
            return currentPresent;
        }

        public Present GetPresent(string name)
        {
            Present currentPresent = data.FirstOrDefault(p => p.Name == name);
            return currentPresent;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");
            foreach (Present item in data)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
