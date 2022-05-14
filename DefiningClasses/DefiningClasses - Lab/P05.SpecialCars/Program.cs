using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != "No more tires")
            {
                AddTires(cmd, tires);
            }

            while ((cmd = Console.ReadLine()) != "Engines done")
            {
                AddEngine(cmd, engines);
            }

            while ((cmd = Console.ReadLine()) != "Show special")
            {
                AddCar(cmd, engines, tires, cars);
            }

            List<Car> specialCars = new List<Car>();
            for (int i = 0; i < cars.Count; i++)
            {
                if (IsSpecial(cars, i))
                {
                    specialCars.Add(cars[i]);
                }
            }

            DriveAllSpecialCars(specialCars);
        }

        private static bool IsSpecial(List<Car> cars, int index)
        {
            double tiresPressurSum = 0;
            foreach (Tire tire in cars[index].Tires)
            {
                tiresPressurSum += tire.Pressure;
            }

            if (cars[index].Year >= 2017 && cars[index].Engine.HorsePower > 330 &&
                 tiresPressurSum > 9.00 && tiresPressurSum < 10.00)
            {
                return true;
            }

            return false;
        }

        private static void AddTires(string cmd, List<Tire[]> allTires)
        {
            string[] tires = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            int[] tiresYear = new int[4]
            {
                    int.Parse(tires[0]), int.Parse(tires[2]),
                    int.Parse(tires[4]), int.Parse(tires[6])
            };

            double[] tiresPressure = new double[4]
            {
                    double.Parse(tires[1]), double.Parse(tires[3]),
                    double.Parse(tires[5]), double.Parse(tires[7])
            };

            Tire[] tiresInfo = new Tire[4]
            {
                    new Tire(tiresYear[0], tiresPressure[0]),
                    new Tire(tiresYear[1], tiresPressure[1]),
                    new Tire(tiresYear[2], tiresPressure[2]),
                    new Tire(tiresYear[3], tiresPressure[3])
            };

            allTires.Add(tiresInfo);
        }

        private static void AddEngine(string cmd, List<Engine> engines)
        {
            string[] engineParams = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int horsePower = int.Parse(engineParams[0]);
            double cubicCapacity = double.Parse(engineParams[1]);

            Engine engine = new Engine(horsePower, cubicCapacity);
            engines.Add(engine);
        }

        private static void AddCar(string cmd, List<Engine> engines, List<Tire[]> allTires, List<Car> cars)
        {
            string[] carInfo = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string make = carInfo[0];
            string model = carInfo[1];
            int year = int.Parse(carInfo[2]);
            double fuelQuantity = double.Parse(carInfo[3]);
            double fuelConsumption = double.Parse(carInfo[4]);
            int engineIndex = int.Parse(carInfo[5]);
            int tiresIndex = int.Parse(carInfo[6]);

            Car newCarToAdd = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], allTires[tiresIndex]);
            cars.Add(newCarToAdd);
        }

        private static void DriveAllSpecialCars(List<Car> specialCars)
        {
            foreach (Car car in specialCars)
            {
                car.Drive(20);

                Console.WriteLine($"Make: {car.Make} {Environment.NewLine}" +
                                  $"Model: { car.Model} {Environment.NewLine}" +
                                  $"Year: { car.Year}{Environment.NewLine}" +
                                  $"HorsePowers: {car.Engine.HorsePower}{Environment.NewLine}" +
                                  $"FuelQuantity: { car.FuelQuantity}");
            }
        }
    }
}
