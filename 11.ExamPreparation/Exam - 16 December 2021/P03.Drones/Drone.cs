﻿using System;

namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public int Range { get; set; }

        public bool Available { get; set; } = true;

        public override string ToString()
        {
            return $"Drone: {this.Name}{Environment.NewLine}" +
                   $"Manufactured by: { this.Brand }{Environment.NewLine}" +
                   $"Range: { this.Range} kilometers";
        }
    }
}
