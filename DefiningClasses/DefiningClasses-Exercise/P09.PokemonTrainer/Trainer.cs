using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string trainerName, Pokemon pokemon)
        {
            this.Name = trainerName;
            this.NumberOfBadges = 0;
            this.Pokemons.Add(pokemon);
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
