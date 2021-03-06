using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Badges = 0;
        }
        public Trainer(string name, int badges, List<Pokemon> pokemons)
            : this(name)
        {
            this.Badges = badges;
            this.Pokemons = pokemons;
        }

        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int badges;
        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        private List<Pokemon> pokemons;
        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }
    }
}
