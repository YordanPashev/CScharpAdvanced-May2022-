﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;

        public string Make { get { return this.make; } set { this.make = value; } }

        public string Model { get { return this.model; } set { this.model = value; } }

        public int Year { get { return this.year; } set { this.year = value; } }

        public double FuelQuantity { get { return this.fuelQuantity; } set { this.fuelQuantity = value; } }

        public double FuelConsumption { get { return this.fuelConsumption; } set { this.fuelConsumption = value; } }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) > 0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
            }

            else
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            string currCarInfo = $"Make: {this.Make} {Environment.NewLine}" +
                                 $"odel: { this.Model} {Environment.NewLine}" +
                                 $"Year: { this.Year}{Environment.NewLine}" +
                                 $"Fuel: { this.FuelQuantity:F2}{Environment.NewLine}";

            return currCarInfo;
        }
    }
}
