using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Func<int, int[], bool> predicate = (n, dividers) => {
                foreach (int divider in dividers)
                {
                    if (n % divider != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            List<int> numbers = Enumerable.Range(1, endNumber).ToList();

            List<int> result = numbers.Where(x => predicate(x, dividers)).ToList();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
