using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public  void TryToDrive(List<Car> cars, string carModel, double amountOfKm)
        {
            int currCarIndex = cars.FindIndex(c => c.Model == carModel);

            if (cars[currCarIndex].FuelAmount >= amountOfKm * cars[currCarIndex].FuelConsumptionPerKilometer)
            {
                cars[currCarIndex].FuelAmount -= amountOfKm * cars[currCarIndex].FuelConsumptionPerKilometer;
                cars[currCarIndex].TravelledDistance += amountOfKm;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
