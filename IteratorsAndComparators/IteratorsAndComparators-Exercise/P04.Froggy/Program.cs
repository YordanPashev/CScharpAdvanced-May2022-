using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> stoneValues = Console.ReadLine()
                         .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(x => int.Parse(x))
                         .ToList();

            Lake stones = new Lake(stoneValues);

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}
