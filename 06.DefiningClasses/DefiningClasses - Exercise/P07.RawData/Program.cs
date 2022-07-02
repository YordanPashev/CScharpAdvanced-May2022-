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

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carSpec = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
                AddCar(cars, carSpec);
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                DisplayAllCarWithCargoFragile(cars);
            }

            else if (type == "flammable")
            {
                DisplayAllCarWithCargoFlammable(cars);

            }
        }

        private static void AddCar(List<Car> cars, string[] carSpec)
        {
            string model = carSpec[0];
            int engineSpeed = int.Parse(carSpec[1]);
            int enginePower = int.Parse(carSpec[2]);
            int cargoWeight = int.Parse(carSpec[3]);
            string cargoType = carSpec[4];

            Tire firstTire = new Tire(double.Parse(carSpec[5]), int.Parse(carSpec[6]));
            Tire secondTire = new Tire(double.Parse(carSpec[7]),int.Parse(carSpec[8]));
            Tire thirdTire = new Tire(double.Parse(carSpec[9]), int.Parse(carSpec[10]));
            Tire fourthTire = new Tire(double.Parse(carSpec[11]),int.Parse(carSpec[12]));

            Tire[] tires = new Tire[4]
            {
                    firstTire, secondTire, thirdTire, fourthTire
            };

            Car newCarToAdd = new Car(model, engineSpeed, enginePower, cargoWeight,
                cargoType, tires);
            cars.Add(newCarToAdd);
        }

        private static void DisplayAllCarWithCargoFragile(List<Car> cars)
        {
            foreach (Car car in cars.Where(c => c.Cargo.Type == "fragile"))
            {
                Tire[] tires = car.Tires;
                foreach (Tire tire in tires)
                {
                    if (tire.Pressure < 1)
                    {
                        Console.WriteLine(car.Model);
                        break;
                    }
                }
            }
        }

        private static void DisplayAllCarWithCargoFlammable(List<Car> cars)
        {
            foreach (Car car in cars.Where(c => c.Cargo.Type == "flammable"))
            {
                if (car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }

    }
}
