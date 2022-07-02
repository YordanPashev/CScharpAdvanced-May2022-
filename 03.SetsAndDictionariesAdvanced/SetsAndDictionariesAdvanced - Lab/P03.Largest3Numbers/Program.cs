using System;
using System.Linq;

namespace P03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int[] sortedArrayOfIntegers = inputLine.OrderByDescending(x => x).Take(3).ToArray();

            Console.WriteLine(string.Join(" ", sortedArrayOfIntegers));
        }
    }
}
