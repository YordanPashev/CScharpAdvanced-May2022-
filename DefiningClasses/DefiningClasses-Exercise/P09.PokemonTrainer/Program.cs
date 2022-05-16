using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Tournament")
            {
                AddTrainerToCollection(trainers, cmd);
            }

            while ((cmd = Console.ReadLine()) != "End")
            {
                string element = cmd;

                ExecuteCmd(trainers, element);
            }

            DisplayAllTrainers(trainers);
        }

        private static void AddTrainerToCollection(Dictionary<string, Trainer> trainers, string cmd)
        {
            string[] cmdArgs = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            string trainerName = cmdArgs[0];
            string pokemonName = cmdArgs[1];
            string pokemonElement = cmdArgs[2];
            int pokemonHealt = int.Parse(cmdArgs[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealt);
            if (!trainers.ContainsKey(trainerName))
            {
                Trainer trainer = new Trainer(trainerName, pokemon);
                trainers.Add(trainerName, trainer);
                return;
            }

            trainers[trainerName].Pokemons.Add(pokemon); 
        }

        private static void ExecuteCmd(Dictionary<string, Trainer> trainers, string element)
        {
            foreach (Trainer trainer in trainers.Values)
            {
                if (trainer.Pokemons.Any(p => p.Element == element))
                {
                    trainer.NumberOfBadges++;
                }

                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        trainer.Pokemons[i].Health -= 10;
                        if (trainer.Pokemons[i].Health <= 0)
                        {
                            trainer.Pokemons.Remove(trainer.Pokemons[i]);
                        }
                    }
                }
            }
        }

        private static void DisplayAllTrainers(Dictionary<string, Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(t => t.Value.NumberOfBadges))
            {
                Console.WriteLine(trainer.Value);
            }
        }
    }
}

