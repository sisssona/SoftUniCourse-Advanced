using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string command;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] pokemonInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
  
                Trainer trainer = trainers.SingleOrDefault(t => t.Name == pokemonInfo[0]);
     

                if (trainer == null)
                {
                    trainer = new(pokemonInfo[0]);
                    trainer.Pokemons.Add(new(pokemonInfo[1], pokemonInfo[2], int.Parse(pokemonInfo[3])));
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(new(pokemonInfo[1], pokemonInfo[2], int.Parse(pokemonInfo[3])));
                }

            }
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Checkelement(command);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }

        }
    }
}


