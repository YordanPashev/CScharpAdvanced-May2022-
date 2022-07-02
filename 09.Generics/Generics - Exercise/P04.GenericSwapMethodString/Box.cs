using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodString
{
    public class Box<T>
    {
        public Box()
        {
            listOfStrings = new List<T>();
        }

        public List<T> listOfStrings { get; set; } 

        public T Text { get; set; }

        public void SwapTwoElements(int firstIndex , int secondIndex)
        {
            T firstElement = listOfStrings[firstIndex];
            listOfStrings[firstIndex] = listOfStrings[secondIndex];
            listOfStrings[secondIndex] = firstElement;
        }
        
        public void Print() => listOfStrings.ForEach(x => Console.WriteLine($"{ typeof(T) }: {x}"));
    }
}
