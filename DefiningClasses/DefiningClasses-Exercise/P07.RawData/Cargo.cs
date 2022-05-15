using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            this.Weight = cargoWeight;
            this.Type = cargoType;
        }

        public string Type { get; set; }

        public int Weight { get; set; }
    }
}
