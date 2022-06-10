using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> customComparator = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }

                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                else if (x > y)
                {
                    return 1;
                }

                else if (y > x)
                {
                    return -1;
                }

                else
                {
                    return 0;
                }
            };

            int[] arrayOfNumberss = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(x => int.Parse(x))
                                     .ToArray();
            Array.Sort(arrayOfNumberss, (x, y) => customComparator(x, y));

            Console.WriteLine(string.Join(" ", arrayOfNumberss));
        }
    }
}
