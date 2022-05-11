using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> printName = n => Console.WriteLine($"Sir {n}");

            names.ForEach(x => printName(x));
        }
    }
}