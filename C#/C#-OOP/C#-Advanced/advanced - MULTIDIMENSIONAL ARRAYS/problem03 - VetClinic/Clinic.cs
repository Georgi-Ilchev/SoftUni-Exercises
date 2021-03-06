using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            data = new List<Pet>();

        }
        public int Capacity { get; set; }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            bool isRemoved = false;
            var result = data.FindAll(p => p.Name == name);
            foreach (var item in result)
            {
                isRemoved = data.Remove(item);
            }
            if (isRemoved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Pet GetPet(string name, string owner)
        {
            var result = data.FirstOrDefault(p => (p.Name == name && p.Owner == owner));
            return result;
        }

        public Pet GetOldestPet()
        {
            var result = data.Find(p => p.Age == data.Max(p => p.Age));
            return result;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();

        }
    }
}

