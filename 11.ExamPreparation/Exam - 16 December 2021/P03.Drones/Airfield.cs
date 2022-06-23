using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public List<Drone> Drones { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) ||
                string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 ||
                drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (Count >= Capacity)
            {
                return "Airfield is full.";
            }

            else
            {
                this.Drones.Add(drone);
                return ($"Successfully added {drone.Name} to the airfield.");
            }
        }

        public bool RemoveDrone(string name)
        {
            var droneToRemove = this.Drones.FirstOrDefault(d => d.Name == name);
            if (droneToRemove != null)
            {
                this.Drones.Remove(droneToRemove);
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
            => this.Drones.RemoveAll(d => d.Brand == brand);

        public Drone FlyDrone(string name)
        {
            var droneToFly = this.Drones.FirstOrDefault(d => d.Name == name);
            if (droneToFly != null)
            {
                droneToFly.Available = false;
                return droneToFly;
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (Drone drone in this.Drones.Where(d => d.Range >= range))
            {
                drone.Available = false;
            }

            return this.Drones.FindAll(d => d.Range >= range);
        }

        public string Report()
        {
            StringBuilder reportResult = new StringBuilder();
            reportResult.AppendLine($"Drones available at {this.Name}:");
            foreach (Drone drone in this.Drones.Where(d => d.Available == true))
            {
                reportResult.AppendLine(drone.ToString());
            }

            return reportResult.ToString().TrimEnd();
        }
    }
}
