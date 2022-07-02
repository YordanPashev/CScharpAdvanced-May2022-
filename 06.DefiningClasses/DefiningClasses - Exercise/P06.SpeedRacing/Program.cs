using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Car car = new Car();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] currCarInfo = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                AddCar(cars, currCarInfo);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string carModel = cmdArgs[1];
                double amountOfKm = Convert.ToDouble(cmdArgs[2]);
                car.TryToDrive(cars, carModel, amountOfKm);
            }

            DisplayAllCarsInfo(cars);
        }

        private static void AddCar(List<Car> cars, string[] currCarInfo)
        {
            string model = currCarInfo[0];
            double fuelAmount = double.Parse(currCarInfo[1]);
            double fuelConsumptionPerKilometer = double.Parse(currCarInfo[2]);
            Car newCArtoAdd = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
            cars.Add(newCArtoAdd);
        }


        private static void DisplayAllCarsInfo(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
