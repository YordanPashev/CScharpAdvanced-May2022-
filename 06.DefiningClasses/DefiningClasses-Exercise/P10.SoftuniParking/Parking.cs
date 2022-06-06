using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;

        private int capacity;

        public int Count { get { return cars.Count; } }
        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {

            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            else if (this.capacity == cars.Count)
            {
                return "Parking is full!";
            }

            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }

            else
            {
                Car carToRemove = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
                cars.Remove(carToRemove);
               return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.Find(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string regNum in registrationNumbers)
            {
                Car carToRemove = cars.FirstOrDefault(c => c.RegistrationNumber == regNum);
                cars.Remove(carToRemove);
            }
        }
    }
}
