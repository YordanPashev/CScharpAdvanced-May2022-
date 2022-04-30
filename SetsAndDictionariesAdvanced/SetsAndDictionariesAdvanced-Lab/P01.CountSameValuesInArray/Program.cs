using System;
using System.Collections.Generic;
using System.Linq;


namespace P01.CountSameValuesInArray
{

    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> numberOccurrances = new Dictionary<double, int>();

            foreach (double digit in numbers)
            {
                if (!numberOccurrances.ContainsKey(digit))
                {
                    numberOccurrances.Add(digit, 0);
                }

                numberOccurrances[digit]++;
            }

            foreach (var occurrance in numberOccurrances)
            {
                Console.WriteLine($"{occurrance.Key} - {occurrance.Value} times");
            }
        }
    }
}
