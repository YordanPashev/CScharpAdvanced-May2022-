using System.Linq;
using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Capacity <= this.Animals.Count)
            {
                return "The zoo is full.";
            }

            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int numberOfAnimalsInSelectedSpecies = this.Animals.FindAll(a => a.Species == species).Count;
            this.Animals.RemoveAll(a => a.Species == species);
            return numberOfAnimalsInSelectedSpecies;
        }

        public List<Animal> GetAnimalsByDiet(string diet) => this.Animals.FindAll(a => a.Diet == diet);

        public Animal GetAnimalByWeight(double weight) => this.Animals.FirstOrDefault(a => a.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = this.Animals.FindAll(a => a.Length >= minimumLength && a.Length <= maximumLength).Count;

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
