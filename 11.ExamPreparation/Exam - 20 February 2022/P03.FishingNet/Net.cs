using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish;
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public IReadOnlyCollection<Fish> Fish => this.fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => this.fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }

            if (Capacity <= Count)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (this.fish.Any(f => f.Weight == weight))
            {
                Fish fish = this.fish.FirstOrDefault(f => f.Weight == weight);
                this.fish.Remove(fish);
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType) => this.fish.FirstOrDefault(f => f.FishType == fishType);

        public Fish GetBiggestFish() => this.fish.OrderByDescending(f => f.Length)
                                                 .FirstOrDefault();

        public string Report()
        {
            StringBuilder fishInfo = new StringBuilder();
            fishInfo.AppendLine($"Into the {this.Material}:");

            foreach (Fish fish in this.fish.OrderByDescending(f => f.Length))
            {
                fishInfo.AppendLine(fish.ToString());
            }

            return fishInfo.ToString().TrimEnd();
        }
    }
}
