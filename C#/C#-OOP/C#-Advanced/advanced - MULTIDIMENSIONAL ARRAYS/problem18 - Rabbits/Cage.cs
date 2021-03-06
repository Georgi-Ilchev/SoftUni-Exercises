using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problem18___Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Rabbit rabbit)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            if (this.data.Any(r => r.Name == name))
            {
                var current = this.data.Where(r => r.Name == name).FirstOrDefault();
                this.data.Remove(current);
                return true;
            }
            return false;
        }
        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(r => r.Species == species);
        }
        public Rabbit SellRabbit (string name)
        {
            Rabbit rabbit = this.data.FirstOrDefault(r => r.Name == name);
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Name == name)
                {
                    this.data[i].Available = false;
                }
            }
            return rabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string speciec)
        {
            var rabbits = new List<Rabbit>();
            foreach (var item in this.data)
            {
                if (item.Species == speciec)
                {
                    item.Available = true ;
                    rabbits.Add(item);
                }
            }
            return rabbits.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var item in this.data.Where(r => r.Available == true))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
