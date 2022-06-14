using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data = new List<Car>();

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Car carToAdd)
        {
            if (Capacity > data.Count)
            {
                data.Add(carToAdd);
            }

        }
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            Car latestCar = data.OrderByDescending(c => c.Year)
                                .FirstOrDefault();

            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car carToRemove = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return carToRemove;
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder(); 
            result.AppendLine($"The cars are parked in {this.Type}:");
            foreach (Car car in data)
            {
                result.AppendLine(car.ToString());
            }

            return result.ToString();
        }
    }
}
