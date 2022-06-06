using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    internal class StartUp
    {

        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineSpec = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                AddEngine(engines, engineSpec);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carSpec = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                AddCAr(cars, engines, carSpec);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void AddEngine(List<Engine> engines, string[] engineSpec)
        {
            string model = engineSpec[0];
            int power = int.Parse(engineSpec[1]);
            int displacement;
            string efficiency = string.Empty;
            Engine newEngineToAdd = new Engine();

            if (engineSpec.Length == 4)
            {
                displacement = int.Parse(engineSpec[2]);
                efficiency = engineSpec[3];
                 newEngineToAdd = new Engine(model, power, displacement, efficiency);
            }

            else if (engineSpec.Length == 3)
            {
                if (int.TryParse(engineSpec[2], out displacement))
                {
                    displacement = int.Parse(engineSpec[2]);
                     newEngineToAdd = new Engine(model, power, displacement);
                }

                else
                {
                    efficiency = engineSpec[2];
                     newEngineToAdd = new Engine(model, power, efficiency);
                }
            }

            else
            {
                 newEngineToAdd = new Engine(model, power);
            }

            engines.Add(newEngineToAdd);
        }


        private static void AddCAr(List<Car> cars, List<Engine> engines, string[] carSpec)
        {
            string model = carSpec[0];
            string engine = carSpec[1];
            int weight;
            string color = string.Empty;
            Car newCarToAdd = new Car();

            if (carSpec.Length == 4)
            {
                weight = int.Parse(carSpec[2]);
                color = carSpec[3];
                 newCarToAdd = new Car(model, engine , weight, color, engines);
            }

            else if (carSpec.Length == 3)
            {
                if (int.TryParse(carSpec[2], out weight))
                {
                    weight = int.Parse(carSpec[2]);
                     newCarToAdd = new Car(model, engine, weight, engines);
                }

                else
                {
                    color = carSpec[2];
                     newCarToAdd = new Car(model, engine, color, engines);
                }
            }

            else
            {
                 newCarToAdd = new Car(model, engine, engines);
            }

            cars.Add(newCarToAdd);
        }
    }
}
