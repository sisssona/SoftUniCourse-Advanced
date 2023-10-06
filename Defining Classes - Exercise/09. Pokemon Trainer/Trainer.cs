using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{ 
    public class Trainer
    {
        public Trainer(string name)
        {
            Name= name;
            Pokemons = new();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void Checkelement (string element)
        {
            if (Pokemons.Any(p => p.Element == element))
            {
                NumberOfBadges++;
            }
            else
            {
               for(int i = 0;i < Pokemons.Count; i++)
                {
                    var currPokemon = Pokemons[i];
                    currPokemon.Health -= 10;
                    if (currPokemon.Health <=0)
                    {
                        Pokemons.Remove(currPokemon);
                    }

                }
            }
        }
    }
}
