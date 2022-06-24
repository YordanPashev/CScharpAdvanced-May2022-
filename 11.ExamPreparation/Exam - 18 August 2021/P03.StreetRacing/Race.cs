using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (!this.Participants.Any(c => c.LicensePlate == car.LicensePlate) && 
                Count < Capacity && car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (this.Participants.Any(c => c.LicensePlate == licensePlate))
            {
                Car carToRemove = this.Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
                this.Participants.Remove(carToRemove);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate) 
            => this.Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar()
            => this.Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();

        public string Report() 
            => $"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps}){ Environment.NewLine }" +
                $"{string.Join(Environment.NewLine , this.Participants)}".TrimEnd(); 
    }
}
