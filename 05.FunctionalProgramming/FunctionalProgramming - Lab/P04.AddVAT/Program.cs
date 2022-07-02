using System;
using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToList();
            Func<decimal, decimal> addVAT = x => x * 1.2m;

            List<decimal> pricesWithVAT = prices.Select(addVAT).ToList();

            pricesWithVAT.ForEach(x => Console.WriteLine($"{x:F2}"));

        }
    }
}
