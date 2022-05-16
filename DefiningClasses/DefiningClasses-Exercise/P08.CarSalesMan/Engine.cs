using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power) 
        {
            this.Model = model;
            this.Power = power;
            this.Efficiency = "n/a";
        }
        public Engine() { }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacementResult;
            if (this.Displacement == 0)
            {
                displacementResult = "n/a";
            }
            else
            {
                displacementResult = this.Displacement.ToString();
            }


            return $"  {this.Model}:{Environment.NewLine}" +
                   $"    Power: {this.Power}{Environment.NewLine}" +
                   $"    Displacement: {displacementResult}{Environment.NewLine}" +
                   $"    Efficiency: {this.Efficiency}";
        }
    }
}
