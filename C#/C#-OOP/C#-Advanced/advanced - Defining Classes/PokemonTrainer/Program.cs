using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                //{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}
                string[] splitted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = splitted[0];
                string pokemonName = splitted[1];
                string pokemonElement = splitted[2];
                int pokemonHealth = int.Parse(splitted[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainerName, trainer);
                }
                trainers[trainerName].Pokemons.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach ((string name, Trainer trainer) in trainers)
                {
                    if (trainer.Pokemons.Any(p=>p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(x => x.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            trainers = trainers.OrderByDescending(t => t.Value.Badges).ToDictionary(x => x.Key, x => x.Value);

            foreach (var trainer in trainers)
            {
                //{trainerName} {badges} {numberOfPokemon};
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
