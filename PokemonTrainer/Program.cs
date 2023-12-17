namespace PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] inputData = input.Split(' ');
                string trainerName = inputData[0];
                string pokemonName = inputData[1];
                string pokemonElement = inputData[2];
                int pokemonHealth = int.Parse(inputData[3]);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    Trainer trainer = new Trainer
                    {
                        Name = trainerName,
                        NumberOfBadges = 0,
                        CollectionOfPokemons = new List<Pokemon>(),
                    };

                    trainers.Add(trainer);
                }

                Pokemon currentPokemon = new Pokemon
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Health = pokemonHealth,
                };

                trainers.First(t => t.Name == trainerName).CollectionOfPokemons.Add(currentPokemon);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.CollectionOfPokemons.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.CollectionOfPokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.CollectionOfPokemons.RemoveAll(p => p.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(t => t.NumberOfBadges)               
                               .ToList();

            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemons.Count}");
            }
        }
    }
}