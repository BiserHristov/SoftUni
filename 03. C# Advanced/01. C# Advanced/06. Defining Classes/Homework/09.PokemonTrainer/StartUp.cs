using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();

            while (line != "Tournament")
            {
                string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = data[0];
                string pokemonName = data[1];
                string element = data[2];
                int health = int.Parse(data[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);
                Trainer trainer = new Trainer(trainerName);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(trainer);
                }

                trainers.Where(t => t.Name == trainerName).FirstOrDefault().Pokemons.Add(pokemon);



                line = Console.ReadLine();
            }


            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            var currentPokemon = trainer.Pokemons[i];
                            currentPokemon.Health -= 10;

                            if (currentPokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(currentPokemon);
                            }
                        }


                    }
                }

                command = Console.ReadLine();

            }

            trainers = trainers.OrderByDescending(t => t.NumberOfBadges).ToList();
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
