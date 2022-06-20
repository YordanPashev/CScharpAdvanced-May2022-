using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    internal class Clinic
    {

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get ; set; }

        public int Count { get { return data.Count; } set { Count = data.Count; } }


        public List<Pet> data { get; set; }

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet petToRemove = data.FirstOrDefault(p => p.Name == name);

            if (petToRemove != null)
            {
                data.Remove(petToRemove);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            if (pet != null)
            {
                return pet;
            }

            return null;
        }

        public Pet GetOldestPet()
        {
            Pet pet = data.OrderByDescending(p => p.Age)
                                  .FirstOrDefault();

            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The clinic has the following patients:");
            foreach (Pet pet in data)
            {
                result.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return result.ToString();
        }
    }
}

