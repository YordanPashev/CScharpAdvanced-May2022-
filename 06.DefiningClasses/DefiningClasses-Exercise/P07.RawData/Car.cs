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
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, 
                   string cargoType, Tire[] tires)
        {
           
            this.Model = model;

            Engine engine = new Engine(engineSpeed, enginePower);
            this.Engine = engine;

            Cargo cargo = new Cargo(cargoWeight, cargoType);
            this.Cargo = cargo;
            this.Tires = tires;
        }
        public string Model { get; set; }
        public Tire[] Tires { get; set; } = new Tire[4];

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }
}
