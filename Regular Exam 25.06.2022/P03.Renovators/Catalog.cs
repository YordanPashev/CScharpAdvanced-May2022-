using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }

        public List<Renovator> renovators { get; set; }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }
        
        public string Project { get; set; }

        public int Count => this.renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) ||
                string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            else if (this.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovatorToRemove = this.renovators.FirstOrDefault(r => r.Name == name);

            if (renovatorToRemove == null)
            {
                return false;
            }

            this.renovators.Remove(renovatorToRemove);
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type) 
            => this.renovators.RemoveAll(r => r.Type == type);

        public Renovator HireRenovator(string name)
        {
            var renovatorToHire = this.renovators.FirstOrDefault(r => r.Name == name);

            if (renovatorToHire == null)
            {
                return null;

            }

            renovatorToHire.Hired = true;
            return renovatorToHire;
        }

        public List<Renovator> PayRenovators(int days)
            => this.renovators.FindAll(r => r.Days >= days);

        public string Report()
            => $"Renovators available for Project {this.Project}:{ Environment.NewLine }" +
               $"{string.Join(Environment.NewLine, this.renovators.Where(r => r.Hired == false))}".TrimEnd();
    }
}
