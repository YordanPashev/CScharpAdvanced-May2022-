using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startNumber = range[0];
            int endNumber = range[1];

            List<int> allNumber = new List<int>();
            List<int> result = new List<int>();

            string command = Console.ReadLine();

            for (int i = startNumber; i <= endNumber; i++)
            {
                allNumber.Add(i);
            }

            if (command == "even")
            {
                Predicate<int> isEven = n => n % 2 == 0;
                result = allNumber.Where(n => isEven(n)).ToList();
            }

            else if (command == "odd")
            {
                Predicate<int> isOdd = n => n % 2 != 0;
                result = allNumber.Where(n => isOdd(n)).ToList();
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
