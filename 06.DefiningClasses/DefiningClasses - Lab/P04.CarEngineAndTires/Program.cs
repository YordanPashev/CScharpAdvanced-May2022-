﻿using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 1.25),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.23)
            };

            Engine engine = new Engine(500, 6300);

            Car newCar = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
        }
    }
}
