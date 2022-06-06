using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            string[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string names = firstInput[0] + " " + firstInput[1];
            string address = firstInput[2];

            MyTuple<string, string> firstTupel = new MyTuple<string, string>(names, address);

            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string name = secondInput[0];
            int amountOfBeerInLiters = int.Parse(secondInput[1]);
            MyTuple<string, int> secondTuplel = new MyTuple<string, int>(name, amountOfBeerInLiters);

            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int integerValue = int.Parse(thirdInput[0]);
            double doubleValue = double.Parse(thirdInput[1]);
            MyTuple<int, double> thidthTuplel = new MyTuple<int, double>(integerValue, doubleValue);

            Console.WriteLine(firstTupel);
            Console.WriteLine(secondTuplel);
            Console.WriteLine(thidthTuplel);
        }
    }
}
