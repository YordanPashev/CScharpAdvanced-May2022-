using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, string engine, List<Engine> engines)
        {
            this.Model = model;
            this.Engine = engines.Find(e => e.Model == engine);
            this.Color = "n/a";

        }
        public Car(string model, string engine, int weight, string color, List<Engine> engines)
            : this(model,  engine,  engines)
        {
            this.Weight = weight;
            this.Color = color; 
        }

        public Car(string model, string engine, int weight, List<Engine> engines) : this(model, engine, engines)
        {
            this.Weight = weight;
            this.Color = "n/a";
        }

        public Car(string model, string engine, string color, List<Engine> engines) : this(model, engine, engines)
        {

            this.Color = color;
        }

        public Car() { }
 
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            string weigthResult;
            if (this.Weight == 0)
            {
                weigthResult = "n/a";
            }

            else
            {
                weigthResult = this.Weight.ToString();
            }

            return $"{this.Model}:{Environment.NewLine}" +
                   $"{this.Engine}{Environment.NewLine}" +
                   $"  Weight: {weigthResult}{Environment.NewLine}" +
                   $"  Color: {this.Color}";
        }
    }
}
