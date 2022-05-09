using System;
using System.Linq;

namespace P01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersToSort = Console.ReadLine()
             .Split(", ", StringSplitOptions.RemoveEmptyEntries)
             .Select(x => int.Parse(x))
             .ToArray();

            numbersToSort = numbersToSort
                .Where(x => x % 2  == 0)
                .OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(", ", numbersToSort));
        }
    }
}
