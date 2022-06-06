using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.PredicateNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxLenght = int.Parse(Console.ReadLine());
            List<string> listOfNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> predicateForNames = (name, allowedLength) => name.Length <= allowedLength;
            List<string> result = listOfNames.Where(x => predicateForNames(x, maxLenght)).ToList();

            Console.WriteLine(string.Join($"{Environment.NewLine}", result));
        }
    }
}
